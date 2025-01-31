using System;
using System.ComponentModel;

namespace IntelligentFactory
{
    [Serializable]
    public class DeviceInfo_Plc
    {
        public enum COMM_TYPE { CCLink, MxComponent, McProtocol };
        [Category("Info"), DisplayName("Type")]
        public COMM_TYPE Type { get; set; } = COMM_TYPE.CCLink;
        [Category("Info (CCLink)"), DisplayName("IP")]
        public string IP { get; set; } = "";

        [Category("Info (CCLink)"), DisplayName("Port")]
        public string Port { get; set; } = "3306";

        [Category("Info (Mx Component)"), DisplayName("LogicalNo")]
        public int LogicalNo { get; set; } = 0;

        public DeviceInfo_Plc()
        {
        }
    }

}
