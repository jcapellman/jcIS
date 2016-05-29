using NOpenCL;

namespace jcIS.WPF.Transports {
    public class jcISDevice {
        public Device NOCLDevice { get; set; }

        public bool IsSelected { get; set; }

        public jcISDevice() { }

        public jcISDevice(Device noclDevice) {
            NOCLDevice = noclDevice;
        }
    }
}