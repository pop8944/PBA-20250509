using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using System.Collections.Concurrent;

namespace IntelligentFactory
{
    public class CNGCount
    {
        public List<NGInfo> NGCount { get; set; } = new List<NGInfo>();

        public CNGCount()
        {
        }

        public CNGCount Load(string modelName)
        {
            string path = $"{Application.StartupPath}\\RECIPE\\{modelName}\\NGCount.json";

            CNGCount newData = null;

            if (File.Exists(path))
            {
                newData = JsonConvert.DeserializeObject<CNGCount>(File.ReadAllText(path), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });

                if (newData != null)
                    return newData;
            }

            newData = new CNGCount();
            newData.Save(modelName);


            return newData;
        }

      
        public void Save(string modelName)
        {
            string path = $"{Application.StartupPath}\\RECIPE\\{modelName}\\NGCount.json";
            string forderpath = $"{Application.StartupPath}\\RECIPE\\{modelName}";
            string currRecipe;

            try
            {
                currRecipe = JsonConvert.SerializeObject(this, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });

                if (!Directory.Exists(forderpath)) Directory.CreateDirectory(forderpath);

                if (File.Exists(path))
                {
                    //이전값과 비교하여 바뀐 부분 로깅
                    string prevRecipe = File.ReadAllText(path);

                    JObject previousObject = JObject.Parse(prevRecipe);
                    JObject currentObject = JObject.Parse(currRecipe);

                    var result = JToken.DeepEquals(previousObject, currentObject);

                }

                File.WriteAllText(path, currRecipe);
            }
            catch (JsonException ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }

    [Serializable]
    public class NGInfo
    {
        public int ArrayNum { get; set; } = 0;
        public string LocationNo { get; set; } = "";
        public string LogicName { get; set; } = "";
        public int NGCount { get; set; } = 0;
    }

    //[Serializable]
    //public class NGLogic
    //{
    //    public string Name { get; set; } = "";
    //    public int NG_Count { get; set; } = 0;
    //}

}
