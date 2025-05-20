using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionParam_Pin : IF_VisionParamObject
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Pin_OkCount")]
        public int Pin_OkCount { get; set; } = 1;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Pin_AreaMin")]
        public int Pin_AreaMin { get; set; } = 10;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Pin_AreaMax")]
        public int Pin_AreaMax { get; set; } = 1000;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Pin_SpecRoiWidth")]
        public int Pin_SpecRoiWidth { get; set; } = 50;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Pin_SpecRoiHeight")]
        public int Pin_SpecRoiHeight { get; set; } = 50;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Pin_Threshold")]
        public int Pin_Threshold { get; set; } = 128;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Pin_BinaryInv")]
        public bool Pin_BinaryInv { get; set; } = false;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Pin_Boundaries")]
        public List<Rectangle> Pin_Boundaries { get; set; } = new List<Rectangle>();

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
