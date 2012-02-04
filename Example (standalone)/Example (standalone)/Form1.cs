using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VideoInputSharp;
using System.Threading;

namespace Example__standalone_
{
	public partial class Form1 : Form
	{
		Capture MyCamera = new Capture();

		public Form1()
		{
			InitializeComponent();
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void listCameras_Click(object sender, EventArgs e)
		{
			var list = VideoInputSharp.Capture.ListDevices();
			cameraList.Items.Clear();

			foreach (var camera in list)
				cameraList.Items.Add(camera);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (isRunning)
				MyCamera.ShowSettings();
		}

		private void cameraList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cameraList.SelectedIndex >= 0)
				groupBox2.Enabled = true;
			else
			{
				groupBox2.Enabled = false;
				groupBox3.Enabled = false;
				Stop();
			}
		
		}

		Thread MyCaptureThread;
		bool isRunning = false;
		int camWidth, camHeight, camFramerate, camIndex;
		int intActualWidth, intActualHeight;
		void Start()
		{
			try
			{
				camIndex = cameraList.SelectedIndex;
				camWidth = System.Convert.ToInt32(this.width.Text);
				camHeight = System.Convert.ToInt32(this.height.Text);
				camFramerate = System.Convert.ToInt32(this.framerate.Text);

				groupBox3.Enabled = true;
				groupBox4.Enabled = true;
				ShowBitmap();

				//capture has to be performed in a seperate thread!
				//make sure to start the thread after you've prepared everything
				//else it might need something before it's available!
				isRunning = true;
				MyCaptureThread = new Thread(ThreadedFunction);
				MyCaptureThread.Start();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Get capture settings failed");
			}
		}

		void Stop()
		{
			if (!isRunning)
				return;

			isRunning = false;
			groupBox3.Enabled = false;
			groupBox4.Enabled = false;
			HideBitmap();
			MyCaptureThread.Join();
		}

		Object MyThreadLock = new Object();
		Bitmap MyImage;
		void ThreadedFunction()
		{
			try
			{
				//you should really do this in a seperate thread!
				//all capture opening, closing and grabbing have to be in the same thread
				MyCamera.Open(camIndex, camFramerate, camWidth, camHeight);

				//Default value is true here, as generally using with OpenCV which stores from top-left
				MyCamera.SetInvertY(false);

				//Default value is false anyway
				MyCamera.SetSwapRGB(false);

				//we now use GetWidth and GetHeight, since the capture might be different res
				//to what we've requested if we requested a bad resolution
				//report the actual dimensions
				intActualWidth = MyCamera.GetWidth();
				intActualHeight = MyCamera.GetHeight();

				//create a bitmap to hold the data
				MyImage = new Bitmap(MyCamera.GetWidth(), MyCamera.GetHeight(), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
				Rectangle rect = new Rectangle(0, 0, MyCamera.GetWidth(), MyCamera.GetHeight());

				while (isRunning)
				{
					lock (MyThreadLock)
					{
						var pixels = MyImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
						MyCamera.GetPixels(pixels.Scan0);
						MyImage.UnlockBits(pixels);
					}
				}

				//when you quit, close will happen automatically.
				//also if you open a different device, close will happen automatically
				MyCamera.Close();
			}
			catch (Exception e)
			{
				isRunning = false;
				MyCamera.Close();
				MessageBox.Show(e.Message, "Capture thread failed");				
			}
		}

		private void start_Click(object sender, EventArgs e)
		{
			Start();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Stop();
		}

		Form PreviewForm;
		PictureBox PreviewImage;
		System.Windows.Forms.Timer PreviewTimer;
		void ShowBitmap()
		{
			if (PreviewForm != null)
				HideBitmap();

			PreviewForm = new Form();
			PreviewForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			PreviewForm.Size = new Size(camWidth, camHeight);

			PreviewImage = new PictureBox();
			PreviewForm.Controls.Add(PreviewImage);
			PreviewImage.Size = PreviewForm.Size;
			PreviewForm.Resize += new EventHandler(PreviewForm_Resize);
			PreviewTimer = new System.Windows.Forms.Timer();
			PreviewTimer.Interval = 10;
			PreviewTimer.Tick += new EventHandler(PreviewTimer_Tick);
			PreviewTimer.Start();

			PreviewForm.Show();
		}

		void PreviewForm_Resize(object sender, EventArgs e)
		{
			PreviewImage.Size = PreviewForm.Size;
		}

		void PreviewTimer_Tick(object sender, EventArgs e)
		{
			if (isRunning)
			{
				actualWidth.Text = intActualWidth.ToString();
				actualHeight.Text = intActualHeight.ToString();

				lock (MyThreadLock)
				{
					PreviewImage.Image = MyImage;
					PreviewImage.Update();
				}
			}
		}

		void HideBitmap()
		{
			if (PreviewForm == null)
				return;
			PreviewForm.Hide();
			PreviewForm.Dispose();
			PreviewImage.Dispose();
			PreviewTimer.Dispose();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Stop();
		}
	}
}
