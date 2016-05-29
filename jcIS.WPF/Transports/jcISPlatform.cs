using System.Collections.Generic;
using System.Linq;

namespace jcIS.WPF.Transports {
    public class jcISPlatform {
        private CL_platform platform { get; set; }

        public List<jcISDevice> GetDevices() => new List<jcISDevice>();// platform.GetDevices().Select(a => new jcISDevice(a)).ToList();
        
        public string Name {  get { return platform.Name; } }

        public jcISPlatform() { }

        public jcISPlatform(CL_platform oclPlatform) {
            platform = oclPlatform;
        }
    }
}