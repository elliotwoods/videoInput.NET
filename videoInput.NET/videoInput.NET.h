// videoInput.NET.h
#include "videoInput.h"

#pragma once

using namespace System;

namespace VideoInputSharp {

	public enum class Property {
		None,

		Brightness,
		Contrast,
		Hue,
		Saturation,
		Sharpness,
		Gamma,
		ColorEnable,
		WhiteBalance,
		BacklightCompensation,
		Gain,

		Pan,
		Tilt,
		Roll,
		Zoom,
		Exposure,
		Iris,
		Focus
	};

	public ref class Capture
	{
	public:
		Capture();
		static array<String^>^ ListDevices();

		/// returns true is succesful
		bool	Open(int DeviceID, int Framerate, int Width, int Height);
		void	Close();

		int		GetWidth();
		int		GetHeight();
		
		void	GetPixels(void* data);
		void	GetPixels(IntPtr data);
		void	ShowSettings();
		/// Value is normalised 0.0f->1.0f
		void	SetProperty(Property Property, float Value);

		void	SetInvertY(bool invertY);
		void	SetSwapRGB(bool swapRGB);

	protected:
		videoInput*	capture;

		bool	initialised;
		int		deviceID;

		int		requestedWidth;
		int		requestedHeight;
		int		actualWidth;
		int		actualHeight;
		unsigned int actualSize;

		bool	swapRGB;
		bool	invertY;
	};
}
