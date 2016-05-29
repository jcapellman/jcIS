using System.Collections.Generic;
using System.Linq;

using NOpenCL;

namespace jcIS.WPF.Transports {
    public class jcISPlatform {
        public Platform NOCLPlatform { get; set; }

        public List<jcISDevice> GetDevices() => NOCLPlatform.GetDevices().ToList().Select(a => new jcISDevice(a)).ToList();
        
        public jcISPlatform() { }

        public jcISPlatform(Platform platform) {
            NOCLPlatform = platform;
        }
    }
}