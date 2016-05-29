#pragma once
#include <CL/cl.h> 
#include <string>

#include "CL_device.h"

#pragma comment(lib, "OpenCL.lib")

using namespace System;

namespace jcIS {

	public ref class CL_platform {
		CL_device^ GetDevices() {
			return gcnew CL_device();
		}
	};
}