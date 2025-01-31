using System;
using System.Reflection;

namespace IntelligentFactory
{
    public class CSetting
    {
        public Setting_Equipment Equipment = null;
        public Setting_Enviroment Enviroment = null;
        public Setting_Recipe Recipe = null;

        public CSetting()
        {
            Equipment = new Setting_Equipment();
            Equipment = Equipment.Load();

            Enviroment = new Setting_Enviroment();
            Enviroment = Enviroment.Load();
        }

        public void Load()
        {
            try
            {
                Equipment = Equipment.Load();
                //Enviroment = Enviroment.Load();
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void Load(string recipeName)
        {
            Recipe = new Setting_Recipe();
            Recipe = Recipe.Load(recipeName);
        }

        public void Save(string recipeName)
        {
            Recipe.Save(recipeName);
        }

        public void Save()
        {
            try
            {
                Equipment.Save();
                Enviroment.Save();

                IF_Util.ShowMessageBox("SAVE", "COMPLETE THE SAVE");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
