using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GETIID
{
    public class Settings
    {
        public string url { get; set; }
        public string remote_server_platform { get; set; }
        public string browser_driver { get; set; }
        public bool portable_mode { get; set; }
        public string remote_server_address { get; set; }
        public string remote_server_port { get; set; }

    }
}
