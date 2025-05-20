using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
namespace IntelligentFactory
{
    public class IF_VisionParam_EYED : IF_VisionParamObject
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Model Name")]
        public string ModelName { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Score Value")]
        public double Score { get; set; } = 0.0;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Rotate Degree Value")]
        public int RotateDgree { get; set; } = 0;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Use Spec Region")]
        public bool UseSpecRegion { get; set; } = false;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("SpecRegion")]
        public Rectangle SpecRegion { get; set; } = new Rectangle(100, 100, 100, 100);

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Use Spec Region")]
        public bool UseColorExRegion { get; set; } = false;
        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("ColorExRegion")]
        public Rectangle ColorExRegion { get; set; } = new Rectangle(100, 100, 100, 100);

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Master (R)")]
        public int MasterR { get; set; } = 30;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Master (G)")]
        public int MasterG { get; set; } = 30;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Master (B)")]
        public int MasterB { get; set; } = 30;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Range")]
        public int Range { get; set; } = 30;

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
