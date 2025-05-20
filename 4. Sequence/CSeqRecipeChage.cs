using System;
using System.Reflection;
using System.Threading;
using Cognex.VisionPro;

namespace IntelligentFactory
{
    public class CSeqRecipeChange : CSeqBase
    {
        private Global Global = Global.Instance;
        public EventHandler<EventArgs> EventRecipeChangeStart;
        public EventHandler<EventArgs> EventRecipeChangeEnd;

        public string RecipeName;
        public CSeqRecipeChange()
        {
            ThreadName = "SEQ_RECIPE_CHAGE";
            //StartThread();
        }

        public void ChageRecipe(string recipeName)
        {
            RecipeName = recipeName;

            EventRecipeChangeStart?.Invoke(this, EventArgs.Empty);
            StartThread();
        }

        public bool IsRecipeChanging = false;

        public override void Run()
        {
            try
            {
                Thread.Sleep(10);

                try
                {
                    IsRecipeChanging = true;
                    //Global.Instance.Data.ResetCurrentCount();
                    Global.FileManager.CountSave(Global.Data);
                    Global.Instance.System.Recipe.Load_NGCount(Global.Instance.System.Recipe.Name);
                    Global.Instance.bRecipeChangeEnd = false;
                    Global.Instance.System.Recipe.LoadTools();
                    //Global.Instance.Setting.Load(Global.System.Recipe.CODE);
                    //Global.Instance.System.Recipe.Load_LibraryManager(Global.System.Recipe.Name);
                    //Global.Instance.System.Recipe.Load_Fiducial(Global.System.Recipe.CODE);
                    //Global.Instance.System.Recipe.LoadCogTools(Global.System.Recipe.Name);
                    //Global.Instance.System.Recipe.Load_MasterLibraryManager("Part", Global.Instance.System.Recipe.CODE);
                    //Global.Instance.System.Recipe.LoadMasterCogTools("Part", Global.Instance.System.Recipe.MasterPartLibrary);
                    //Global.Instance.System.Recipe.Load_MasterLibraryManager("Library", Global.Instance.System.Recipe.CODE);
                    //Global.Instance.System.Recipe.LoadMasterCogTools("Library", Global.Instance.System.Recipe.MasterLibrary);
                    Global.Instance.FrmVision.SetRecipeInfo();
                    Global.Instance.FrmVision.SetFiducialInfo();
                    Global.Instance.FrmVision.ClearCogDisp();
                    CLogger.Add(LOG.NORMAL, $"[Model : {Global.System.Recipe.Name}]LoadTools");
                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

                }
                catch (Exception ex)
                {
                    IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }

                EventRecipeChangeEnd?.Invoke(this, EventArgs.Empty);
                StopThread();

                IsRecipeChanging = false;

                return;
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
            finally
            {
                EventRecipeChangeEnd?.Invoke(this, EventArgs.Empty);

            }
        }
    }
}

