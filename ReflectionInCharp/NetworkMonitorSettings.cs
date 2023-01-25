using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionInCharp
{
    public  class NetworkMonitorSettings
    {
        public string WarningService { get; set; }
        public string MethodToExecute { get; set; }
        public Dictionary<string, object> PropertyBag { get; set; } =
            new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    }
}
