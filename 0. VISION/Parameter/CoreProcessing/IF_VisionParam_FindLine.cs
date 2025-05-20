using System;
using System.ComponentModel;

using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.PMAlign;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionParam_FindLine : IF_VisionParamObject
    {
        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Use Angle Judge")]
        public bool UseAngleJudge { get; set; } = false;

        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Min Angle (º)")]
        public double MinimumAngle { get; set; } = 0.0D;

        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Max Angle (º)")]
        public double MaximumAngle { get; set; } = 360.0D;

        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Use DistanceX Judge")]
        public bool UseDistanceXJudge { get; set; } = false;

        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Min DistanceX (px)")]
        public double MinimumDistanceX { get; set; } = 0.0D;

        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Max DistanceX (px)")]
        public double MaximumDistanceX { get; set; } = 360.0D;

        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Use DistanceY Judge")]
        public bool UseDistanceYJudge { get; set; } = false;

        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Min DistanceY (px)")]
        public double MinimumDistanceY { get; set; } = 0.0D;

        [CategoryAttribute("Specifiation"), DescriptionAttribute(""), DisplayNameAttribute("Max DistanceY (px)")]
        public double MaximumDistanceY { get; set; } = 360.0D;

        [CategoryAttribute("Tool"), DescriptionAttribute(""), DisplayNameAttribute("Tool Path (Main)")]
        public string ToolMain_Path { get; set; } = "";

        [Newtonsoft.Json.JsonIgnore]
        public CogFindLineTool ToolMain { get; set; } = null;

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
