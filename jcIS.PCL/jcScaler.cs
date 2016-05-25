using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NOpenCL;
using Buffer = NOpenCL.Buffer;

namespace jcIS.PCL
{
    public class jcScaler
    {
        public List<Platform> GetPlatforms() => Platform.GetPlatforms().ToList();

        public void CreateBuffer(Platform platform)
        {
            using (Context context = Context.Create(platform.GetDevices())) {
                using (Buffer buffer = context.CreateBuffer(MemoryFlags.AllocateHostPointer, 1024)) {
                    
                }
            }
        }
    }
}
