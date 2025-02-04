using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    [Serializable]
    public class IF_VisionLogicInfo
    {
        public string PartCode { get; set; } = "";
        public string LocationNo { get; set; } = "";

        public int PosX { get; set; }
        public int PosY { get; set; }
        public double PosAngle { get; set; }
        public string Description { get; set; } = "";
        public bool Enabled { get; set; } = false;        

        public List<IF_VisionParamObject> Logics { get; set; }
        public IF_VisionLogicInfo(string name)
        {
            PartCode = name;
        }

        //public IF_VisionLogicInfo Load(string libraryName)
        //{
        //    string path = $"{Application.StartupPath}\\LIBRARY\\{libraryName}\\{PartCode}.json";


        //    IF_VisionLogicInfo newData = null;

        //    if (File.Exists(path))
        //    {
        //        newData = JsonConvert.DeserializeObject<IF_VisionLogicInfo>(File.ReadAllText(path), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        //        if (newData != null)
        //            return newData;
        //    }

        //    newData = new IF_VisionLogicInfo(PartCode);
        //    newData.Save(libraryName);
        //    return newData;
        //}

        //public void Save(string libraryName)
        //{
            
        //    string path = $"{Application.StartupPath}\\LIBRARY\\{libraryName}\\{PartCode}.json";
        //    string currRecipe;

        //    try
        //    {
        //        currRecipe = JsonConvert.SerializeObject(this, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        //        if (File.Exists(path))
        //        {
        //            //이전값과 비교하여 바뀐 부분 로깅
        //            string prevRecipe = File.ReadAllText(path);

        //            JObject previousObject = JObject.Parse(prevRecipe);
        //            JObject currentObject = JObject.Parse(currRecipe);

        //            var result = JToken.DeepEquals(previousObject, currentObject);

        //            //if (!result)
        //            //{
        //            //    foreach (var item in previousObject)
        //            //    {
        //            //        if (!JToken.DeepEquals(item.Value, currentObject[item.Key]))
        //            //        {
        //            //            CLogger.Add(LOG.NORMAL, $"Property '{item.Key}' changed from '{item.Value}' to '{currentObject[item.Key]}'");
        //            //        }
        //            //    }
        //            //}
        //            //else
        //            //{
        //            //    Console.WriteLine("JSON objects are equal");
        //            //}
        //        }

        //        File.WriteAllText(path, currRecipe);
        //    }
        //    catch (JsonException ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //    }
        //}
    }
}
