using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.Json;

namespace IntelligentFactory
{
    public class DeviceInfo_ModbusTcp
    {
        public string IP { get; set; }
        public int Port { get; set; } = 502;

        [Category("Info"), DisplayName("Name")]
        public string Name { get; set; } = "";
        public int ReadTimeOut_ms { get; set; } = 1000;

        public DeviceInfo_ModbusTcp()
        {
        }
    }
}
