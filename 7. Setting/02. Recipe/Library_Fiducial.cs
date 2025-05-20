using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Library_Fiducial
    {
        public Recipe_FiducialMatching Fiducial1 { get; set; } = new Recipe_FiducialMatching("Fiducial1");
        public string LibraryNumber { get; set; } = "0";
        public string Code { get; set; } = "867C";
        public double MasterAngle { get; set; }
        public int FiducialGrabIndex { get; set; } = 0;

        public List<Rectangle> RegionArrayList { get; set; } // 기존 RegionArrayX 들을 대체할 리스트
        public List<PointF> OffsetArrayList { get; set; }    // 기존 OffsetArrayX 들을 대체할 리스트

        [JsonIgnore]
        public Bitmap MasterImage;
        [JsonIgnore]
        public Bitmap ImagePreview;
        public string Name
        {
            get { return Code; }
            set { Code = value; }
        }

        public Library_Fiducial()
        {
            RegionArrayList = new List<Rectangle>();
            OffsetArrayList = new List<PointF>();
            int defaultNumberOfArrays = 12;

            for (int i = 0; i < defaultNumberOfArrays; i++)
            {
                RegionArrayList.Add(new Rectangle(100, 100, 100, 100));
                OffsetArrayList.Add(new PointF(0, 0));
            }
        }
        public void Save(string libraryCode)
        {
            string path = $"{Application.StartupPath}\\LIBRARY\\PBA_LIBRARY\\{libraryCode}\\FiducialLibrary_.json";
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string currRecipe;

            try
            {
                currRecipe = System.Text.Json.JsonSerializer.Serialize(this, options);
                File.WriteAllText(path, currRecipe);
            }
            catch (JsonException)
            {
            }
            catch (Exception)
            {
            }

            try { Fiducial1?.SaveImages(libraryCode, Fiducial1.Name); } catch (Exception) { }
            try { IF_Util.SafetyImageSave($"{Application.StartupPath}\\LIBRARY\\PBA_LIBRARY\\{libraryCode}\\FiducialLibrary_Preview.bmp", ImagePreview); } catch (Exception) { }
            try { IF_Util.SafetyImageSave($"{Application.StartupPath}\\LIBRARY\\PBA_LIBRARY\\{libraryCode}\\FiducialLibrary_Master.bmp", MasterImage); } catch (Exception) { }
        }

        public Library_Fiducial Load(string libraryCode)
        {
            if (string.IsNullOrEmpty(libraryCode) || libraryCode == "\r\n")
            {
                libraryCode = "867C";
            }
            string path = $"{Application.StartupPath}\\LIBRARY\\PBA_LIBRARY\\{libraryCode}\\FiducialLibrary_.json";
            Library_Fiducial newData = null;

            if (File.Exists(path))
            {
                try
                {
                    newData = System.Text.Json.JsonSerializer.Deserialize<Library_Fiducial>(File.ReadAllText(path));
                }
                catch (Exception) { }

                if (newData != null)
                {
                    if (newData.RegionArrayList == null || newData.RegionArrayList.Count != 12)
                    {
                        newData.RegionArrayList = new List<Rectangle>();
                        for (int i = 0; i < 12; i++) newData.RegionArrayList.Add(new Rectangle(100, 100, 100, 100));
                    }
                    if (newData.OffsetArrayList == null || newData.OffsetArrayList.Count != 12)
                    {
                        newData.OffsetArrayList = new List<PointF>();
                        for (int i = 0; i < 12; i++) newData.OffsetArrayList.Add(PointF.Empty);
                    }

                    try { newData.Fiducial1?.LoadImages(libraryCode, newData.Fiducial1.Name); } catch (Exception) { }
                    try
                    {
                        newData.ImagePreview = IF_Util.SafetyImageLoad($"{Application.StartupPath}\\LIBRARY\\PBA_LIBRARY\\{libraryCode}\\FiducialLibrary_Preview.bmp");
                    }
                    catch (Exception) { }
                    return newData;
                }
            }

            newData = new Library_Fiducial();
            newData.Save(libraryCode);
            return newData;
        }

        public Rectangle GetArrayRegion(int idx)
        {
            if (idx >= 0 && idx < RegionArrayList.Count)
            {
                return RegionArrayList[idx];
            }
            return Rectangle.Empty;
        }

        public void SetArrayRegion(int idx, Rectangle value)
        {
            if (idx >= 0 && idx < RegionArrayList.Count)
            {
                RegionArrayList[idx] = value;
            }
        }

        public PointF GetArrayOffset(int idx)
        {
            if (idx >= 0 && idx < OffsetArrayList.Count)
            {
                return OffsetArrayList[idx];
            }
            return PointF.Empty;
        }

        public void SetArrayOffset(int idx, PointF value)
        {
            if (idx >= 0 && idx < OffsetArrayList.Count)
            {
                OffsetArrayList[idx] = value;
            }
        }

    }
}
