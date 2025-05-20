using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class MasterLibraryManager
    {
        public string Name { get; set; } = "";
        public ConcurrentDictionary<int, List<IF_VisionLogicInfo>> Library { get; set; } = new ConcurrentDictionary<int, List<IF_VisionLogicInfo>>();

        public MasterLibraryManager()
        {

        }

        public MasterLibraryManager Load(string masterpath, string libraryCode)
        {
            string path = $"{Application.StartupPath}\\LIBRARY\\MASTER_LIBRARY\\{libraryCode}\\{masterpath}\\Recipe.json";

            MasterLibraryManager newData = null;

            if (File.Exists(path))
            {
                newData = JsonConvert.DeserializeObject<MasterLibraryManager>(File.ReadAllText(path), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });

                if (newData != null)
                    return newData;
            }

            newData = new MasterLibraryManager();
            newData.Save(masterpath, libraryCode);


            return newData;
        }

      
        public void Save(string masterpath,string libraryCode)
        {
            string path = $"{Application.StartupPath}\\LIBRARY\\MASTER_LIBRARY\\{libraryCode}\\{masterpath}\\Recipe.json";
            string forderpath = $"{Application.StartupPath}\\LIBRARY\\MASTER_LIBRARY\\{libraryCode}\\{masterpath}";
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
