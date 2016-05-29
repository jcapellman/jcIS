#pragma once

#include <CL/cl.hpp> 

#pragma comment(lib, "OpenCL.lib")

using namespace System;

namespace jcIS {
	public ref class CL_device {
		public:
			String^ GetName() {
				return "";
			}
		private:
			cl::Device* m_device;
	};
}