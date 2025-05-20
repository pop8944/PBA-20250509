using ImageProcessing;
using OpenCvSharp;
using System;
using System.ComponentModel;
using static IntelligentFactory.Form_MenuVision;

namespace IntelligentFactory._0._VISION.Parameter
{
    [Serializable]
    public class IF_VisionParam_Equalization : IF_ImageProcessing
    {
        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Equalization Type")]
        public EqualizationType EqualizationType { get; set; } = EqualizationType.EqualizeHist;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Tile Grid Size X")]
        public int TileGridSizeX { get; set; } = 8;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Tile Grid Size Y")]
        public int TileGridSizeY { get; set; } = 8;

        [CategoryAttribute("Parameter"), DescriptionAttribute(""), DisplayNameAttribute("Clip Limit")]
        public double ClipLimit { get; set; } = 2.0;


        public IF_VisionParam_Equalization()
        {
            EqualizationType = EqualizationType.EqualizeHist;
            TileGridSizeX = 8;
            TileGridSizeY = 8; 
            ClipLimit = 2.0; 
        }

    }
}
