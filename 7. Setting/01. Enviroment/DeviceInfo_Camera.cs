using System.ComponentModel;
using System.Drawing;

namespace IntelligentFactory
{
    public class DeviceInfo_Camera
    {
        [Category("Info"), DisplayName("IP / HostName")]
        public string IP { get; set; } = "192.168.100.100";

        [Category("Info"), DisplayName("Serial Number")]
        public string SerialNumber { get; set; } = "F25942222";

        [Category("Info"), DisplayName("Rotation")]
        public RotateFlipType Rotation { get; set; } = RotateFlipType.RotateNoneFlipNone;

        [CategoryAttribute("PARAMETER"), DescriptionAttribute(""), DisplayNameAttribute("FlipRotate")]
        public string FLIPROTATE { get; set; } = "";

        [CategoryAttribute("SIZE"), DescriptionAttribute(""), DisplayNameAttribute("WIDTH")]
        public int WIDTH { get; set; } = 4024;

        [CategoryAttribute("SIZE"), DescriptionAttribute(""), DisplayNameAttribute("HEIGHT")]
        public int HEIGHT { get; set; } = 3036;

        [Category("Info"), DisplayName("Pixel Size X (mm)")]
        public double PixelSizeX_L_mm { get; set; } = 0.005D;

        [Category("Info"), DisplayName("Pixel Size Y (mm)")]
        public double PixelSizeY_L_mm { get; set; } = 0.005D;

        public double SensorHeight_L { get; set; } = 3340;

        public double PixelSizeX_H_mm { get; set; } = 0.005D;
        public double PixelSizeY_H_mm { get; set; } = 0.005D;
        public double SensorHeight_H { get; set; } = 3340;


        public string CamFilePath { get; set; } = "";
        public float DefaultExposureTime { get; set; } = 10000.0F;
        public int DefaultGain { get; set; } = 1;

        public DeviceInfo_Camera()
        {
        }
    }
}
