// This is the main DLL file.

#include "stdafx.h"

#include "videoInput.NET.h"

namespace VideoInput {

	Capture::Capture()
	{
		capture = new videoInput();
	}

	array<String^>^ Capture::ListDevices()
	{
		int nDevices = videoInput::listDevices(true);
		array<String^>^ names = gcnew array<String^>(nDevices);
		
		for (int i=0; i<nDevices; i++)
			names[i] = gcnew String(reinterpret_cast<const char*>(videoInput::getDeviceName(i)));
			
		return names;
	}
}