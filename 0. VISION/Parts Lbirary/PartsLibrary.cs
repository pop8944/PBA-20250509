using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    public class PartsLibrary
    {
        public string Name { get; set; } = "";

        public ConcurrentDictionary<int, List<IF_VisionLogicManager>> Library { get; set; } = null;
        
        public PartsLibrary(string name)
        {
            Name = name;
        }

        public PartsLibrary Load(string libraryName)
        {
            string path = $"{Application.StartupPath}\\LIBRARY\\{libraryName}\\{Name}.json";


            PartsLibrary newData = null;

            if (File.Exists(path))
            {
                newData = JsonConvert.DeserializeObject<PartsLibrary>(File.ReadAllText(path), new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

                if (newData != null)
                    return newData;
            }

            newData = new PartsLibrary(Name);
            newData.Save(libraryName);
            return newData;
        }

        public PartsLibrary LoadGerber(string gerberPath)
        {
            PartsLibrary newData = new PartsLibrary(Name);
            List<PBA_GerberInfo> parts = PBA_GerberHelper.GetGerberInfo(gerberPath);

            // 가장 큰 ArrayIndex 값
            int arrayCount = parts.Max(p => p.ArrayIndex);

            newData.Library.Clear();

            for (int i = 0; i < arrayCount; i++)
            {
                newData.Library.TryAdd((i + 1), new List<IF_VisionLogicManager>());
            }
            
            //Library
            foreach (var part in parts)
            {
                newData.Library[part.ArrayIndex].Add(new IF_VisionLogicManager(part.PartCode)
                {
                    LocationNo = part.LocationNo,
                    PosX = double.Parse(part.PosX),
                    PosY = double.Parse(part.PosY),
                    PosAngle = double.Parse(part.PosAngle),
                    Enabled = part.Enabled
                });
            }

            return newData;
        }

        public void Save(string libraryName)
        {

            string path = $"{Application.StartupPath}\\LIBRARY\\{libraryName}\\{Name}.json";
            string currRecipe;

            try
            {
                currRecipe = JsonConvert.SerializeObject(this, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

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
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
