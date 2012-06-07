// This is the main DLL file.

#include "stdafx.h"

#include "videoInput.NET.h"

namespace VideoInputSharp {

	Capture::Capture()
	{
		capture = new videoInput();
		initialised = false;
		swapRGB = false;
		invertY = true;
	}

	array<String^>^ Capture::ListDevices()
	{
		int nDevices = videoInput::listDevices(true);
		array<String^>^ names = gcnew array<String^>(nDevices);
		
		for (int i=0; i<nDevices; i++)
			names[i] = gcnew String(reinterpret_cast<const char*>(videoInput::getDeviceName(i)));
			
		return names;
	}

	bool Capture::Open(int DeviceID, int Framerate, int Width, int Height)
	{
		Close();

		try
		{
			deviceID = DeviceID;
			capture->setIdealFramerate(deviceID, Framerate);
			capture->setupDevice(deviceID, Width, Height);

			requestedWidth = Width;
			requestedHeight = Height;
			initialised = true;
			return true;
		}
		catch (...)
		{
			initialised = false;
			return false;
		}
	}

	void Capture::Close()
	{
		if (!initialised)
			return;
		capture->stopDevice(deviceID);
		initialised = false;
	}

	int Capture::GetWidth()
	{
		if (!initialised)
			return 0;
		else
			return capture->getWidth(deviceID);
	}

	int Capture::GetHeight()
	{
		if (!initialised)
			return 0;
		else
			return capture->getHeight(deviceID);
	}

	void Capture::GetPixels(void* data)
	{
		if (!initialised)
			return;
		capture->getPixels(deviceID, (unsigned char *)data, swapRGB, invertY);
	}

	void Capture::GetPixels(IntPtr data)
	{
		this->GetPixels(data.ToPointer());
	}

	void Capture::ShowSettings()
	{
		if (!initialised)
			return;
		capture->showSettingsWindow(deviceID);
	}

	void Capture::SetProperty(Property Property, float Value)
	{
		if (!initialised)
			return;

		long videoInputProperty;
		bool filterOrCamera; //false = filter, true = camera

		switch(Property)
		{
			
		//software (filter) settings

		case Property::Brightness:
			videoInputProperty = capture->propBrightness;
			filterOrCamera = false;
			break;

		case Property::Contrast:
			videoInputProperty = capture->propContrast;
			filterOrCamera = false;
			break;

		case Property::Hue:
			videoInputProperty = capture->propHue;
			filterOrCamera = false;
			break;

		case Property::Saturation:
			videoInputProperty = capture->propSaturation;
			filterOrCamera = false;
			break;
			
		case Property::Sharpness:
			videoInputProperty = capture->propSharpness;
			filterOrCamera = false;
			break;

		case Property::Gamma:
			videoInputProperty = capture->propGamma;
			filterOrCamera = false;
			break;

		case Property::ColorEnable:
			videoInputProperty = capture->propColorEnable;
			filterOrCamera = false;
			break;

		case Property::WhiteBalance:
			videoInputProperty = capture->propWhiteBalance;
			filterOrCamera = false;
			break;
			
		case Property::BacklightCompensation:
			videoInputProperty = capture->propBacklightCompensation;
			filterOrCamera = false;
			break;

		case Property::Gain:
			videoInputProperty = capture->propGain;
			filterOrCamera = false;
			break;


		//hardware (camera) settings

		case Property::Pan:
			videoInputProperty = capture->propPan;
			filterOrCamera = true;
			break;

		case Property::Tilt:
			videoInputProperty = capture->propTilt;
			filterOrCamera = true;
			break;

		case Property::Roll:
			videoInputProperty = capture->propRoll;
			filterOrCamera = true;
			break;
			
		case Property::Zoom:
			videoInputProperty = capture->propZoom;
			filterOrCamera = true;
			break;

		case Property::Exposure:
			videoInputProperty = capture->propExposure;
			filterOrCamera = true;
			break;

		case Property::Iris:
			videoInputProperty = capture->propIris;
			filterOrCamera = true;
			break;

		case Property::Focus:
			videoInputProperty = capture->propFocus;
			filterOrCamera = true;
			break;

			
		default:
			return;
		}

		if (!filterOrCamera)
			capture->setVideoSettingFilterPct(deviceID, videoInputProperty, Value);
		else
			capture->setVideoSettingCameraPct(deviceID, videoInputProperty, Value);
	}

	void Capture::SetInvertY(bool invertY) {
		this->invertY = invertY;
	}

	void Capture::SetSwapRGB(bool swapRGB) {
		this->swapRGB = swapRGB;
	}
}