// videoInput.NET.h
#include "videoInput.h"

#pragma once

using namespace System;

namespace VideoInput {

	public ref class Capture
	{
	public:
		Capture();
		static array<String^>^ ListDevices();

	protected:
		videoInput*	capture;
	};
}
