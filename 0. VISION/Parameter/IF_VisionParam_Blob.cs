using System;
using System.ComponentModel;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionParam_Blob : IF_VisionParamObject
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Threshold Type")]
        public IF_ImageProcessing.ThresholdTypes ThresholdType { get; set; } = IF_ImageProcessing.ThresholdTypes.Binary;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Threshold Value")]
        public int Threshold { get; set; } = 10;
        
        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Min Area (px)")]
        public int MinArea { get; set; } = 10;

        [CategoryAttribute("Specification"), DescriptionAttribute(""), DisplayNameAttribute("Max Area (px)")]
        public int MaxArea { get; set; } = 10000;

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
