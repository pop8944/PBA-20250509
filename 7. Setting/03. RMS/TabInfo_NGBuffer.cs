using System.ComponentModel;

namespace IntelligentFactory
{
    public class TabInfo_NGBuffer
    {
        [Category("Info"), DisplayName("NG_REASON")]
        public string NG_REASON { get; set; } = "Not_Insert";

        [Category("Info"), DisplayName("Check_ALL")]
        public bool Check_ALL { get; set; } = false;

        public TabInfo_NGBuffer()
        {
        }
    }
}
