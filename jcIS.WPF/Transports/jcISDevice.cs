namespace jcIS.WPF.Transports {
    public class jcISDevice {
        private CL_device device { get; set; }

        public string Name { get { return device.GetName(); } }

        public bool IsSelected { get; set; }

        public jcISDevice() { }

        public jcISDevice(CL_device oclDevice) {
            device = oclDevice;
        }
    }
}