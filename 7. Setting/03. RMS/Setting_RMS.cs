using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Setting_RMS
    {
        public TabInfo_NGBuffer NGBuffer { get; set; } = new TabInfo_NGBuffer();
        public Dictionary<int, string> dicBUFFER_ID_Done = new Dictionary<int, string>();
        public Setting_RMS()
        {
        }

        public Setting_RMS Load()
        {
            string path = $"{Application.StartupPath}\\CONFIG\\Setting_RMS.json";


            Setting_RMS newData = null;

            if (File.Exists(path))
            {
                newData = JsonSerializer.Deserialize<Setting_RMS>(File.ReadAllText(path));

                if (newData != null)
                    return newData;
            }

            newData = new Setting_RMS();
            newData.Save();
            return newData;
        }

        public void Save()
        {
            string path = $"{Application.StartupPath}\\CONFIG\\Setting_RMS.json";

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

                    //if (!result)
                    //{
                    //    foreach (var item in previousObject)
                    //    {
                    //        if (!JToken.DeepEquals(item.Value, currentObject[item.Key]))
                    //        {
                    //            CLogger.Add(LOG.NORMAL, $"Property '{item.Key}' changed from '{item.Value}' to '{currentObject[item.Key]}'");
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    Console.WriteLine("JSON objects are equal");
                    //}
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
