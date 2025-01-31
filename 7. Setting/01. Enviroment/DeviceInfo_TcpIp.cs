using System.ComponentModel;

namespace IntelligentFactory
{
    public class DeviceInfo_TcpIp
    {
        public string ServerIP { get; set; } = "127.0.0.1";
        public string ClientIP { get; set; } = "127.0.0.1";

        public int ServerPort { get; set; } = 5000;
        public int ClientPort { get; set; } = 5000;
        public bool IsServer { get; set; } = false;

        [Category("Info"), DisplayName("Name")]
        public string Name { get; set; } = "";
        public int ReadTimeOut_ms { get; set; } = 1000;
        public int RetryConnectInterval_ms { get; set; } = 3000;

        public string StartParser { get; set; } = "[";
        public string EndParser { get; set; } = "]";
        public bool UseCR { get; set; } = true;
        public bool UseLF { get; set; } = true;
        public DeviceInfo_TcpIp()
        {
        }
    }
}
