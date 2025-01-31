using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Library_Fiducial
    {
        public string LibraryNumber { get; set; } = "";
        public string Memo { get; set; } = "";
        public Recipe_FiducialMatching Fiducial1 { get; set; } = new Recipe_FiducialMatching("Fiducial1");
        public Recipe_FiducialMatching Fiducial2 { get; set; } = new Recipe_FiducialMatching("Fiducial2");

        public double MasterAngle { get; set; }

        public int FiducialGrabIndex { get; set; } = 0;

        public Rectangle RegionArray1 { get; set; } = new Rectangle(100, 100, 100, 100);
        public Rectangle RegionArray2 { get; set; } = new Rectangle(100, 100, 100, 100);
        public Rectangle RegionArray3 { get; set; } = new Rectangle(100, 100, 100, 100);
        public Rectangle RegionArray4 { get; set; } = new Rectangle(100, 100, 100, 100);

        public PointF OffsetArray1 { get; set; } = new PointF(0, 0);
        public PointF OffsetArray2 { get; set; } = new PointF(0, 0);
        public PointF OffsetArray3 { get; set; } = new PointF(0, 0);
        public PointF OffsetArray4 { get; set; } = new PointF(0, 0);

        [JsonIgnore]
        public Bitmap ImagePreview;

        public Library_Fiducial()
        {
        }

        public Library_Fiducial Load(string partLibraryCode, string libraryNumber)
        {
            if (string.IsNullOrEmpty(libraryNumber) || libraryNumber == "\r\n")
            {
                libraryNumber = "0";
            }

            string path = $"{Application.StartupPath}\\PBA_LIBRARY\\{partLibraryCode}\\FIDUCIAL_LIBRARY\\FiducialLibrary_{libraryNumber}.json";
            Library_Fiducial newData = null;



            if (File.Exists(path))
            {
                try { newData = JsonSerializer.Deserialize<Library_Fiducial>(File.ReadAllText(path)); } catch (Exception ex) { }

                if (newData != null)
                {
                    try { newData.Fiducial1.LoadImages(partLibraryCode, libraryNumber, Fiducial1.Name); } catch (Exception ex) { }
                    try { newData.Fiducial2.LoadImages(partLibraryCode, libraryNumber, Fiducial2.Name); } catch (Exception ex) { }
                    try
                    {
                        ImagePreview = IF_Util.SafetyImageLoad($"{Application.StartupPath}\\PBA_LIBRARY\\{partLibraryCode}\\FIDUCIAL_LIBRARY\\FiducialLibrary_{libraryNumber}_Preview.bmp");
                    }
                    catch (Exception ex) { }

                    return newData;
                }
            }

            newData = new Library_Fiducial();
            newData.Save(partLibraryCode, libraryNumber);
            return newData;
        }

        public Rectangle GetArrayRegion(int idx)
        {
            if (idx == 0) return RegionArray1;
            if (idx == 1) return RegionArray2;
            if (idx == 2) return RegionArray3;
            if (idx == 3) return RegionArray4;

            return new Rectangle();
        }

        public void Save(string partLibraryCode, string libraryNumber)
        {
            string path = $"{Application.StartupPath}\\PBA_LIBRARY\\{partLibraryCode}\\FIDUCIAL_LIBRARY\\FiducialLibrary_{libraryNumber}.json";
            Directory.CreateDirectory(Path.GetDirectoryName(path));


            JsonSerializerOptions options = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                WriteIndented = true
            };

            string currRecipe;

            try
            {
                currRecipe = JsonSerializer.Serialize(this, options);

                if (File.Exists(path))
                {
                    //이전값과 비교하여 바뀐 부분 로깅
                    string prevRecipe = File.ReadAllText(path);

                    JObject previousObject = JObject.Parse(prevRecipe);
                    JObject currentObject = JObject.Parse(currRecipe);

                    var result = JToken.DeepEquals(previousObject, currentObject);

                    if (!result)
                    {
                        foreach (var item in previousObject)
                        {
                            if (!JToken.DeepEquals(item.Value, currentObject[item.Key]))
                            {
                                CLogger.Add(LOG.NORMAL, $"Property '{item.Key}' changed'");//from '{item.Value}' to '{currentObject[item.Key]}'");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("JSON objects are equal");
                    }
                }


                File.WriteAllText(path, currRecipe);
            }
            catch (JsonException ex)
            {
                options.IgnoreNullValues = true;
                currRecipe = JsonSerializer.Serialize(this, options);
                File.WriteAllText(path, currRecipe);

                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }

            try { Fiducial1.SaveImages(partLibraryCode, libraryNumber, Fiducial1.Name); } catch (Exception ex) { }
            try { Fiducial2.SaveImages(partLibraryCode, libraryNumber, Fiducial2.Name); } catch (Exception ex) { }
            try { IF_Util.SafetyImageSave($"{Application.StartupPath}\\PBA_LIBRARY\\{partLibraryCode}\\FIDUCIAL_LIBRARY\\FiducialLibrary_{libraryNumber}_Preview.bmp", ImagePreview); } catch (Exception ex) { }
        }

    }
}
