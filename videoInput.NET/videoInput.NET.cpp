// This is the main DLL file.

#include "stdafx.h"

#include "videoInput.NET.h"

namespace VideoInputSharp {

	Capture::Capture()
	{
		capture = new videoInput();
		initialised = false;
	}

	array<String^>^ Capture::ListDevices()
	{
		int nDevices = videoInput::listDevices(true);
		array<String^>^ names = gcnew array<String^>(nDevices);
		
		for (int i=0; i<nDevices; i++)
			names[i] = gcnew String(reinterpret_cast<const char*>(videoInput::getDeviceName(i)));
			
		return names;
	}

	void Capture::Open(int DeviceID, int Framerate, int Width, int Height)
	{
		Close();

		deviceID = DeviceID;
		capture->setIdealFramerate(deviceID, Framerate);
		capture->setupDevice(deviceID, Width, Height);

		requestedWidth = Width;
		requestedHeight = Height;
		actualWidth = capture->getWidth(deviceID);
		actualHeight = capture->getHeight(deviceID);
		actualSize = capture->getSize(deviceID);
		initialised = true;
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
			return actualWidth;
	}

	int Capture::GetHeight()
	{
		if (!initialised)
			return 0;
		else
			return actualHeight;
	}

	void Capture::GetPixels(void* data)
	{
		capture->getPixels(deviceID, (unsigned char *)data, false, true);
	}

	void Capture::ShowSettings()
	{
		if (!initialised)
			return;
		capture->showSettingsWindow(deviceID);
	}


}