using OpenCvSharp;
using System;
using System.Drawing;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Recipe_Matching
    {
        public string Name { get; set; }
        [JsonIgnore]
        public Bitmap ImageTemplate;
        public double ScoreMin { get; set; }
        public Rectangle SearchRoi { get; set; } = new Rectangle(0, 0, 100, 100);
        public Rectangle TemplateRoi { get; set; } = new Rectangle(0, 0, 100, 100);

        public double Mag_1st { get; set; } = 2.0D;
        public double Mag_2nd { get; set; } = 1.0D;

        public Recipe_Matching(string name = "")
        {
            Name = name;
        }

        public bool LoadImages(string recipeName, string name)
        {
            try
            {
                ImageTemplate = IF_Util.SafetyImageLoad($"{Application.StartupPath}\\RECIPE\\{recipeName}\\{name}.bmp");
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        public bool SaveImages(string recipeName, string name)
        {
            try
            {
                IF_Util.SafetyImageSave($"{Application.StartupPath}\\RECIPE\\{recipeName}\\{name}.bmp", ImageTemplate);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }
    }

    public class Recipe_FiducialMatching
    {
        public string Name { get; set; }
        [JsonIgnore]
        public Bitmap ImageTemplate;
        public double ScoreMin { get; set; }
        public Rectangle SearchRoi { get; set; } = new Rectangle(0, 0, 100, 100);
        public Rectangle TemplateRoi { get; set; } = new Rectangle(0, 0, 100, 100);

        public Point2d Origin { get; set; }
        public double Mag_1st { get; set; } = 2.0D;
        public double Mag_2nd { get; set; } = 1.0D;

        public Recipe_FiducialMatching(string name = "")
        {
            Name = name;
        }

        public bool LoadImages(string libraryCode, string name)
        {
            try
            {
                string path = $"{Application.StartupPath}\\LIBRARY\\PBA_LIBRARY\\{libraryCode}\\FiducialLibrary_{name}.bmp";
                ImageTemplate = IF_Util.SafetyImageLoad(path);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        public bool SaveImages( string libraryCode, string name)
        {
            try
            {
                string path = $"{Application.StartupPath}\\LIBRARY\\PBA_LIBRARY\\{libraryCode}\\FiducialLibrary_{name}.bmp";
                IF_Util.SafetyImageSave(path, ImageTemplate);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }
    }
}
