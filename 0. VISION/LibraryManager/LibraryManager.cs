using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentFactory
{
    public class LibraryManager
    {
        public string Name { get; set; } = "";
        public string FiducialCode { get; set; } = "867C";
        public ConcurrentDictionary<int, List<IF_VisionLogicInfo>> Library { get; set; } = new ConcurrentDictionary<int, List<IF_VisionLogicInfo>>();

        public LibraryManager()
        {
            
        }

        public LibraryManager Load(string libraryName)
        {
            string path = $"{Application.StartupPath}\\RECIPE\\{libraryName}\\Recipe.json";

            LibraryManager newData = null;

            if (File.Exists(path))
            {
                newData = JsonConvert.DeserializeObject<LibraryManager>(File.ReadAllText(path), new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });

                if (newData != null)
                    return newData;
            }
                
            newData = new LibraryManager();
            newData.Save(libraryName);

          
            return newData;
        }

        public LibraryManager LoadGerber(string gerberPath)
        {
            LibraryManager newData = new LibraryManager();
            List<PBA_GerberInfo> parts = PBA_GerberHelper.GetGerberInfo(gerberPath);

            // 가장 큰 ArrayIndex 값
            int arrayCount = parts.Max(p => p.ArrayIndex);

            if (newData.Library != null) newData.Library.Clear();

            for (int i = 0;  i < arrayCount;  i++)
            {
                newData.Library.TryAdd((i + 1), new List<IF_VisionLogicInfo>());
            }

            //Library
            foreach (var part in parts)
            {
                newData.Library[part.ArrayIndex].Add(new IF_VisionLogicInfo()
                {
                    LocationNo = part.LocationNo,
                    PosX = (int)(double.Parse(part.PosX) / 0.068),
                    PosY = (int)(Global.Instance.System.Recipe.FiducialLibrary.RegionArray1.Height - double.Parse(part.PosY) / 0.068),
                    PosAngle = double.Parse(part.PosAngle),
                    Enabled = part.Enabled,
                    PartCode = part.PartCode,
                });
            }

            return newData;
        }
        public void Save(string libraryName)
        {
            string path = $"{Application.StartupPath}\\RECIPE\\{libraryName}\\Recipe.json";
            string forderpath = $"{Application.StartupPath}\\RECIPE\\{libraryName}";
            string currRecipe;

            try
            {
                currRecipe = JsonConvert.SerializeObject(this, new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });

                if(!Directory.Exists(forderpath)) Directory.CreateDirectory(forderpath);

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
        public string GetHash()
        {
            // 여기서 부터 작업
            // 1. Library 변수를 직렬화
            string libraryData = JsonConvert.SerializeObject(Library);

            // 2. 해쉬값 생성 
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(libraryData));
                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}
