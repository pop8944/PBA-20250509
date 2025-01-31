using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml.Serialization;

namespace IntelligentFactory
{
    public class DeviceInfo_TriggerBoard
    {
        [Category("Info"), DisplayName("Name")]
        public string Name { get; set; } = "";

        [Category("Info"), DisplayName("Port Name")]
        public string PortName { get; set; } = "COM1";

        [Category("Info"), DisplayName("Baudrate")]
        public int Baudrate { get; set; } = 9600;

        [XmlIgnore, JsonIgnore]
        public byte BaudRateIdx
        {
            get
            {
                switch (Baudrate)
                {
                    case 4800: return 0;
                    case 9600: return 1;
                    case 14400: return 2;
                    case 19200: return 3;
                    case 38400: return 4;
                    case 56000: return 5;
                    case 57600: return 6;
                    case 115200: return 7;
                }

                return 7;
            }
        }

        [XmlIgnore, JsonIgnore]
        public int PortNum
        {
            get
            {
                if (PortName.Length >= 4)
                {
                    string strPortNum = PortName.Substring(3, PortName.Length - 3);
                    return int.Parse(strPortNum);
                }

                return 1;
            }
        }

        public DeviceInfo_TriggerBoard()
        {
        }

    }
}
