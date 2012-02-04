namespace Example__standalone_
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cameraList = new System.Windows.Forms.ListBox();
			this.listCameras = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.width = new System.Windows.Forms.TextBox();
			this.height = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.start = new System.Windows.Forms.Button();
			this.framerate = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.showSettings = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.actualHeight = new System.Windows.Forms.TextBox();
			this.actualWidth = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cameraList);
			this.groupBox1.Controls.Add(this.listCameras);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 129);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "1. List cameras";
			// 
			// cameraList
			// 
			this.cameraList.FormattingEnabled = true;
			this.cameraList.Location = new System.Drawing.Point(6, 46);
			this.cameraList.Name = "cameraList";
			this.cameraList.Size = new System.Drawing.Size(368, 69);
			this.cameraList.TabIndex = 3;
			this.cameraList.SelectedIndexChanged += new System.EventHandler(this.cameraList_SelectedIndexChanged);
			// 
			// listCameras
			// 
			this.listCameras.Location = new System.Drawing.Point(6, 19);
			this.listCameras.Name = "listCameras";
			this.listCameras.Size = new System.Drawing.Size(368, 21);
			this.listCameras.TabIndex = 2;
			this.listCameras.Text = "List cameras [.ListDevices()]";
			this.listCameras.UseVisualStyleBackColor = true;
			this.listCameras.Click += new System.EventHandler(this.listCameras_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.framerate);
			this.groupBox2.Controls.Add(this.start);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.height);
			this.groupBox2.Controls.Add(this.width);
			this.groupBox2.Enabled = false;
			this.groupBox2.Location = new System.Drawing.Point(12, 151);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(379, 77);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "2. Select dimensions";
			// 
			// width
			// 
			this.width.Location = new System.Drawing.Point(42, 19);
			this.width.Name = "width";
			this.width.Size = new System.Drawing.Size(84, 20);
			this.width.TabIndex = 0;
			this.width.Text = "640";
			this.width.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// height
			// 
			this.height.Location = new System.Drawing.Point(150, 19);
			this.height.Name = "height";
			this.height.Size = new System.Drawing.Size(84, 20);
			this.height.TabIndex = 1;
			this.height.Text = "480";
			this.height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(132, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(12, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "x";
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(6, 48);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(367, 23);
			this.start.TabIndex = 3;
			this.start.Text = "Start capture [.Open(devicenumber,framerate,width,height)]";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// framerate
			// 
			this.framerate.Location = new System.Drawing.Point(255, 19);
			this.framerate.Name = "framerate";
			this.framerate.Size = new System.Drawing.Size(53, 20);
			this.framerate.TabIndex = 4;
			this.framerate.Text = "30";
			this.framerate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(237, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(18, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "@";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(314, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "fps";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.actualHeight);
			this.groupBox3.Controls.Add(this.actualWidth);
			this.groupBox3.Controls.Add(this.showSettings);
			this.groupBox3.Enabled = false;
			this.groupBox3.Location = new System.Drawing.Point(12, 234);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(380, 82);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "3. Open settings dialog";
			// 
			// showSettings
			// 
			this.showSettings.Location = new System.Drawing.Point(6, 19);
			this.showSettings.Name = "showSettings";
			this.showSettings.Size = new System.Drawing.Size(367, 23);
			this.showSettings.TabIndex = 4;
			this.showSettings.Text = "Show settings [.ShowSettings()]";
			this.showSettings.UseVisualStyleBackColor = true;
			this.showSettings.Click += new System.EventHandler(this.button1_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(181, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(12, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "x";
			// 
			// actualHeight
			// 
			this.actualHeight.Location = new System.Drawing.Point(199, 48);
			this.actualHeight.Name = "actualHeight";
			this.actualHeight.Size = new System.Drawing.Size(84, 20);
			this.actualHeight.TabIndex = 6;
			this.actualHeight.Text = "480";
			this.actualHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// actualWidth
			// 
			this.actualWidth.Location = new System.Drawing.Point(91, 48);
			this.actualWidth.Name = "actualWidth";
			this.actualWidth.Size = new System.Drawing.Size(84, 20);
			this.actualWidth.TabIndex = 5;
			this.actualWidth.Text = "640";
			this.actualWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.button1);
			this.groupBox4.Location = new System.Drawing.Point(12, 322);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(380, 53);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "4. Close camera";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(6, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(367, 21);
			this.button1.TabIndex = 0;
			this.button1.Text = "Stop capture [.Close()]";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(404, 384);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "VideoInput.NET demo";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox cameraList;
		private System.Windows.Forms.Button listCameras;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox height;
		private System.Windows.Forms.TextBox width;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox framerate;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button showSettings;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox actualHeight;
		private System.Windows.Forms.TextBox actualWidth;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button button1;

	}
}

