using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Setting_Enviroment
    {
        public enum COUNTRY : int { KOR, POL, MAL };
        public COUNTRY Country { get; set; } = COUNTRY.KOR;

        public DeviceInfo_Camera Camera1 { get; set; } = new DeviceInfo_Camera();
        public DeviceInfo_TcpIp EyeD { get; set; } = new DeviceInfo_TcpIp();

        public ParamInfo_Color ColorList { get; set; } = new ParamInfo_Color();
        public Setting_Enviroment()
        {
        }

        public Setting_Enviroment Load()
        {
            string path = $"{Application.StartupPath}\\CONFIG\\Setting_Enviroment.json";


            Setting_Enviroment newData = null;

            if (File.Exists(path))
            {
                newData = JsonSerializer.Deserialize<Setting_Enviroment>(File.ReadAllText(path));

                if (newData != null)
                    return newData;
            }

            newData = new Setting_Enviroment();
            newData.Save();
            return newData;
        }

        public void Save()
        {
            string path = $"{Application.StartupPath}\\CONFIG\\Setting_Enviroment.json";

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
