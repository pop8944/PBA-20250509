using System.ComponentModel;

namespace IntelligentFactory
{
    public class DeviceInfo_AutoFocus
    {
        public string IP { get; set; }
        public int Port { get; set; } = 502;

        [Category("Info"), DisplayName("Name")]
        public string Name { get; set; } = "";

        public DeviceInfo_AutoFocus()
        {
        }
    }
}
