using System;
using System.ComponentModel;
using System.Drawing;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionParam_ColorEx : IF_VisionParamObject
    {
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

        public Color GetMasterColor()
        {
            return Color.FromArgb(MasterR, MasterG, MasterB);
        }
    }
}
