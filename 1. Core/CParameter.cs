using System;
using System.Reflection;

namespace IntelligentFactory
{
    public class CParameter
    {
        public CParameter_ImageProcess Cam1_ImageProcess = null;
        public CParameter_ImageProcess Cam2_ImageProcess = null;

        public CParameter()
        {
            Cam1_ImageProcess = new CParameter_ImageProcess();
            Cam1_ImageProcess.Name = "CAM1";
            Cam2_ImageProcess = new CParameter_ImageProcess();
            Cam2_ImageProcess.Name = "CAM2";

            Cam1_ImageProcess = Cam1_ImageProcess.LoadConfig();
            Cam2_ImageProcess = Cam2_ImageProcess.LoadConfig();
        }

        public void Load(string strRecipe)
        {
            try
            {
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void Save(string strRecipe)
        {
            try
            {
                Cam1_ImageProcess.SaveConfig();
                Cam2_ImageProcess.SaveConfig();

                IF_Util.ShowMessageBox("SAVE", "COMPLETE THE SAVE");
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}