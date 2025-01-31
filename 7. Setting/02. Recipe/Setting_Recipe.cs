using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace IntelligentFactory
{
    [Serializable]
    public class Setting_Recipe
    {
        public Recipe_Insp Insp { get; set; } = new Recipe_Insp();

        public Setting_Recipe()
        {
        }

        public Setting_Recipe Load(string recipeName)
        {
            string path = $"{Application.StartupPath}\\RECIPE\\{recipeName}\\Setting.json";

            Setting_Recipe newData = null;

            if (File.Exists(path))
            {
                try { newData = JsonSerializer.Deserialize<Setting_Recipe>(File.ReadAllText(path)); } catch (Exception ex) { }

                if (newData != null)
                    return newData;
            }

            newData = new Setting_Recipe();
            newData.Save(recipeName);
            return newData;
        }

        public void Save(string recipeName)
        {
            string path = $"{Application.StartupPath}\\RECIPE\\{recipeName}\\Setting.json";
            Directory.CreateDirectory($"{Application.StartupPath}\\RECIPE\\{recipeName}\\");

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
        }

    }
}
