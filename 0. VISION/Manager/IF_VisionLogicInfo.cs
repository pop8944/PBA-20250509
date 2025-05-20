using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionLogicInfo :ICloneable
    {
        public string LocationNo { get; set; } = ""; // ID
        public string PartCode { get; set; } = "";

        public int PosX { get; set; }
        public int PosY { get; set; }
        public double PosAngle { get; set; }
        public string Description { get; set; } = "";
        public bool Enabled { get; set; } = false;
        public int LogicCount { get; set; } = 0;
        //public Dictionary<string, IF_VisionParamObject> Logics { get; set; }
        public List<IF_VisionParamObject> Logics { get; set; } = new List<IF_VisionParamObject>();

        public IF_VisionLogicInfo()
        {
           
        }
        public object Clone()
        {
            return new IF_VisionLogicInfo
            {
                LocationNo = this.LocationNo,
                PartCode = this.PartCode,
                PosX = this.PosX,
                PosY = this.PosY,
                PosAngle = this.PosAngle,
                Description = this.Description,
                Enabled = this.Enabled,
                LogicCount = this.LogicCount,
                Logics = this.Logics.Select(logic => (IF_VisionParamObject)logic.Clone()).ToList()
            };

        }
    }
}
