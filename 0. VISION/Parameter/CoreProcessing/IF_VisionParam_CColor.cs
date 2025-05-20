using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntelligentFactory._0._VISION.Parameter.CoreProcessing
{
    [Serializable]
    public class IF_VisionParam_CColor : IF_VisionParamObject
    {
        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("ColorCoordinate")]
        public ColorCoordinate CCoordinate { get; set; } = ColorCoordinate.CC_GRAY;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("ColorMethod")]
        public ColorMethod CMethod { get; set; } = ColorMethod.CA_THRESHILD;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("ValueRect")]
        public Rectangle ValueRect { get; set; } = new Rectangle(100, 100, 100, 100);

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("00) Use Color Range")]
        public bool UseColorRange { get; set; } = true;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("00) Min (0)")]
        public int Min0 { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("00) Max (0)")]
        public int Max0 { get; set; } = 255;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("01) Min (1)")]
        public int Min1 { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("01) Max (1)")]
        public int Max1 { get; set; } = 255;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("02) Min (2)")]
        public int Min2 { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("02) Max (2)")]
        public int Max2 { get; set; } = 255;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("03) Range Area Min")]
        public int RangeAreaMin { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("03) Range Area Max")]
        public int RangeAreaMax { get; set; } = 0;

        [CategoryAttribute("Color Range"), DescriptionAttribute(""), DisplayNameAttribute("04) Threshold")]
        public int Threshold { get; set; } = 128;

        public enum ColorCoordinate
        {
            CC_GRAY = 0,
            CC_BGR,
            CC_HSV,
            CC_XYZ,
            CC_YUV,
        }
        public enum ColorMethod
        {
            CA_THRESHILD = 0,
            CA_RANGE,
            CA_ConvertGray,
        }
        public override IF_VisionParamObject Clone()
        {
            // 직렬화 시 실제 타입 정보를 포함시키기 위해 TypeNameHandling을 설정
            string serialize = JsonConvert.SerializeObject(this, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            // 역직렬화 시 TypeNameHandling을 설정
            IF_VisionParamObject deserialize = JsonConvert.DeserializeObject<IF_VisionParamObject>(serialize, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

            return deserialize;
        }
        
    }
}
