using System.ComponentModel;

namespace IntelligentFactory
{
    public class DeviceInfo_Database
    {
        [Category("Info"), DisplayName("IP / HostName")]
        public string IP { get; set; } = "";

        [Category("Info"), DisplayName("Port")]
        public string Port { get; set; } = "3306";

        [Category("Info"), DisplayName("User")]
        public string User { get; set; } = "";

        [Category("Info"), DisplayName("Password")]
        public string Password { get; set; } = "";

        [Category("Info"), DisplayName("Name")]
        public string Name { get; set; } = "";

        public string charSet { get; set; } = "utf8";

        public DeviceInfo_Database()
        {
        }
    }
}
