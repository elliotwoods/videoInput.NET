// videoInput.NET.h
#include "videoInput.h"

#pragma once

using namespace System;

namespace VideoInputSharp {

	public ref class Capture
	{
	public:
		Capture();
		static array<String^>^ ListDevices();

		void	Open(int DeviceID, int Framerate, int Width, int Height);
		void	Close();

		int		GetWidth();
		int		GetHeight();
		
		void	GetPixels(void* data);
		void	ShowSettings();

	protected:
		videoInput*	capture;

		bool	initialised;
		int		deviceID;

		int		requestedWidth;
		int		requestedHeight;
		int		actualWidth;
		int		actualHeight;
		unsigned int actualSize;

	};
}
