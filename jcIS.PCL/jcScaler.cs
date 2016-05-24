using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NOpenCL;

namespace jcIS.PCL
{
    public class jcScaler
    {
        public List<Platform> GetPlatforms() => Platform.GetPlatforms().ToList();
    }
}
