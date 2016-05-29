using NOpenCL;

namespace jcIS.WPF.Transports {
    public class jcISDevice {
        private Device NOCLDevice { get; set; }

        public string Name { get { return NOCLDevice.Name; } }

        public bool IsSelected { get; set; }

        public jcISDevice() { }

        public jcISDevice(Device noclDevice) {
            NOCLDevice = noclDevice;
        }
    }
}