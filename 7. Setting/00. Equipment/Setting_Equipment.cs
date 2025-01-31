using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Setting_Equipment
    {
        public enum ImageSaveTarget
        {
            ALL,
            NG_ONLY
        }

        public int DelayTime_PrevInsp { get; set; } = 0;

        [Category("Local_Image_Save"), DisplayName("Type")]
        public ImageSaveTarget ImageSaveOption { get; set; } = ImageSaveTarget.ALL;

        [Category("Local_Image_Save"), DisplayName("Last Day Use")]
        public bool ImageSaveLastDayEnable { get; set; } = false;

        [Category("Local_Image_Save"), DisplayName("Last Day Count")]
        public int ImageSaveLastDay { get; set; } = 30;

        [Category("Local_Image_Save"), DisplayName("Disk Check Use")]
        public bool ImageSaveDiskCheckEnable { get; set; } = false;

        [Category("Local_Image_Save"), DisplayName("Disk Check Percent")]
        public int ImageSaveDiskCheckPercent { get; set; } = 90;

        [Category("Local_Image_Save"), DisplayName("Max Count Use")]
        public bool ImageSaveMaxCountEnable { get; set; } = false;

        [Category("Local_Image_Save"), DisplayName("Max Count")]
        public int ImageSaveMaxCount { get; set; } = 500;


        [Category("Equipment"), DisplayName("Name")]
        public string EquipmentName { get; set; } = "MVS-200";

        [Category("Equipment"), DisplayName("Number")]
        public string EquipmentNumber { get; set; } = "#101";


        public Setting_Equipment()
        {
        }

        public Setting_Equipment Load()
        {
            string path = $"{Application.StartupPath}\\CONFIG\\Setting_Equipment.json";


            Setting_Equipment newData = null;

            if (File.Exists(path))
            {
                newData = JsonSerializer.Deserialize<Setting_Equipment>(File.ReadAllText(path));

                if (newData != null)
                    return newData;
            }

            newData = new Setting_Equipment();
            newData.Save();
            return newData;
        }

        public void Save()
        {
            string path = $"{Application.StartupPath}\\CONFIG\\Setting_Equipment.json";

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
                                CLogger.Add(LOG.NORMAL, $"Property '{item.Key}' changed from '{item.Value}' to '{currentObject[item.Key]}'");
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
        }
    }
}
