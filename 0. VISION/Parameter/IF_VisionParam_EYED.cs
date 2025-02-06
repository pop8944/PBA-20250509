using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;

namespace IntelligentFactory._0._VISION.Parameter
{
    public class IF_VisionParam_EYED : IF_VisionParamObject
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Model Path")]
        public string ModelPath { get; set; }

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Threshold Value")]
        public double Threshold { get; set; } = 0.0;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Rotate Degree Value")]
        public List<int> RotateDgree { get; set; } = new List<int>{ 0, 90, 180, 270 };

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Use Spec Region")]
        public bool UseSpecRegion { get; set; }
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
