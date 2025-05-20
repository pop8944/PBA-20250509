using Cognex.VisionPro.Caliper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionParam_Condensor : IF_VisionParamObject
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Polarity Type")]
        public string CondensorPolarity { get; set; } = "T";
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Rect Width")]
        public int CondensorRectWidth { get; set; } = 50;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Rect Height")]
        public int CondensorRectHeight { get; set; } = 50;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Find Type")]
        public bool CondensorTypeTB { get; set; } = false;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Radius Offset")]
        public int CondensorRadiusOffset { get; set; } = 0;
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Radius Offset")]
        public int MinFoundCount { get; set; } = 1;


        [Newtonsoft.Json.JsonIgnore]
        public CogFindCircleTool Find_Circle = new CogFindCircleTool();

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
