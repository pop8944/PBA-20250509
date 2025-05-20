using System;
using System.ComponentModel;
using Cognex.VisionPro.PMAlign;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionParam_Matching : IF_VisionParamObject
    {
        [CategoryAttribute("Score"), DescriptionAttribute(""), DisplayNameAttribute("Min Score Judge (0.0 - 1.0)")]
        public double MinimumScore_forJudge { get; set; } = 0.5;
        [CategoryAttribute("Score"), DescriptionAttribute(""), DisplayNameAttribute("Min Score Find (0.0 - 1.0)")]
        public double MinimumScore_forFind { get; set; } = 0.01;

     
        [Newtonsoft.Json.JsonIgnore]
        public CogPMAlignTool[] PMAlignTools { get; set; } =
        {
            new CogPMAlignTool(),
            new CogPMAlignTool(),
            new CogPMAlignTool(),
            new CogPMAlignTool(),
            new CogPMAlignTool()
        };
     
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
