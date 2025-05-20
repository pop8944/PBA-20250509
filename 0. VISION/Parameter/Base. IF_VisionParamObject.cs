using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using ImageProcessing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    [Serializable]
    public abstract class IF_VisionParamObject
    {
        public bool HasChanged = false;

        public bool Enabled { get; set; } = false;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        //기존 Not OK 기능에 대한 변수로 조건 만족 시 OK 판정이면 true, NG 판정이면 false
        public bool JudgeType_Judge_NaisNg { get; set; } = true;
        public int SamplingCount { get; set; } = 1;
        public int GrabIndex { get; set; } = 0;
        public int ID { get; set; } = 0;

        #region 기본 파라미터
        public Rectangle SearchRegion { get; set; } = new Rectangle(100, 100, 100, 100);
        //티칭 시 SearchRegion 의 Origin Point (Left Top 기준)
        public Point SearchRegion_Origin { get; set; } = new Point(100, 100);
        public bool UseToolAlign { get; set; } = true;
        public Point ToolAlign_Offset { get; set; } = new Point(0, 0);
        #endregion

        #region 전처리 관련
        public bool UseImageProcessing { get; set; } = false;

        public Dictionary<string, IF_ImageProcessing> ImgProcessingList { get; set; } = new Dictionary<string, IF_ImageProcessing>();
        #endregion

        public IF_VisionParamObject()
        {
            ID = this.GetHashCode();
        }

        public abstract IF_VisionParamObject Clone();
    }


    [Serializable]
    public class IF_ImageProcessing 
    {
        public bool ImageType { get; set; } = false; // false Color, True Mono
        public ImageProcessingMethod Type { get; set; }
    }
}
