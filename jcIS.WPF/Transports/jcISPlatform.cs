using System.Collections.Generic;
using System.Linq;

using NOpenCL;

namespace jcIS.WPF.Transports {
    public class jcISPlatform {
        private Platform NOCLPlatform { get; set; }

        public List<jcISDevice> GetDevices() => NOCLPlatform.GetDevices().ToList().Select(a => new jcISDevice(a)).ToList();
        
        public string Name {  get { return NOCLPlatform.Name; } }

        public jcISPlatform() { }

        public jcISPlatform(Platform platform) {
            NOCLPlatform = platform;
        }
    }
}