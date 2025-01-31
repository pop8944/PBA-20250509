using System.ComponentModel;

namespace IntelligentFactory
{
    public class DeviceInfo_LightController
    {
        [Category("Info"), DisplayName("Port Name")]
        public string PortName { get; set; } = "COM1";

        [Category("Info"), DisplayName("Baudrate")]
        public string Baudrate { get; set; } = "9600";

        [Category("Info"), DisplayName("Name")]
        public string Name { get; set; } = "";

        public enum TYPE { STD, ONE_PORT, SPOT, ALIGN, IPULSE };

        [Category("Info"), DisplayName("Type")]
        public TYPE Type { get; set; } = TYPE.ALIGN;

        public DeviceInfo_LightController()
        {
        }
    }
}
