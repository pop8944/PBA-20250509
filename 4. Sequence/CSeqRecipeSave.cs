using System;
using System.Reflection;
using System.Threading;

namespace IntelligentFactory
{
    public class CSeqRecipeSave : CSeqBase
    {
        private Global Global = Global.Instance;
        public EventHandler<EventArgs> EventRecipeSaveStart;
        public EventHandler<EventArgs> EventRecipeSaveEnd;

        public string RecipeName;
        public CSeqRecipeSave()
        {
            ThreadName = "SEQ_RECIPE_SAVE";
            //StartThread();
        }

        public void Save(string recipeName)
        {
            RecipeName = recipeName;
            EventRecipeSaveStart?.Invoke(this, EventArgs.Empty);
            StartThread();
        }

        public override void Run()
        {
            try
            {
                Thread.Sleep(10);

                try
                {
                    Global.Setting.Save(Global.System.Recipe.Name);

                    // 비정상적인 레시피 이름이 있을경우...레시피 이름 변경후 저장 요청...
                    if (RecipeName_Check())
                    {
                        StopThread();
                        return;
                    }
                    else
                    {
                        Global.Instance.SelectedMenu = "Main";
                        CRecipe.RecipeSaving_Flg = true;
                        CRecipe.RecipeSaving_CheckCnt = 1;          // 세이브 상태의 프로그레스 표시를 위한 값..
                                                                    //저장 때 살려놓기

                        CRecipe.RecipeSaving_CheckCnt = 3;
                        Global.Instance.System.Recipe.RecipeSave();
                        CRecipe.RecipeSaving_CheckCnt = 10;
                        CRecipe.RecipeSaving_Flg = false;
                    }
                }
                catch (Exception ex)
                {
                    IF_Util.ShowMessageBox("Error", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
                    CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                }


            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"Ex ==> {MethodBase.GetCurrentMethod().Name}==>{ex.Message}");
            }
            finally
            {
                StopThread();
                EventRecipeSaveEnd?.Invoke(this, EventArgs.Empty);

            }
        }

        private bool RecipeName_Check()
        {
            bool ret = false;
            for (int i = 0; i < Global.Instance.System.Recipe.JobManager.Length; i++)
            {
                if (Global.Instance.System.Recipe.JobManager[i] == null) return false;

                for (int j = 0; j < Global.Instance.System.Recipe.JobManager[i].Jobs.Count; j++)
                {
                    // 메인툴에서 Enabled데이터중에서 매칭 이미지가 있는지 체크..
                    if (Global.Instance.System.Recipe.JobManager[i].Jobs[j].Enabled)
                    {
                        // 현재 이미지가 트레인되어있지 않을시 진행하지 않음..
                        if (Global.Instance.System.Recipe.JobManager[i].Jobs[j].Type == "Pattern")
                        {
                            if (!Global.Instance.System.Recipe.JobManager[i].Jobs[j].Tool.Tool.Pattern.Trained)
                            {
                                IF_Util.ShowMessageBox("Trained CHECK", $"Recipe No Trained..Recipe Pattern Train Please => Recipe Name : {Global.Instance.System.Recipe.JobManager[i].Jobs[j].Name}, Recipe Array Number : {i + 1}, Recipe Number : {j + 1}");
                                return true;
                            }
                        }
                    }

                    // 별도의 NEW라는 이름이 있는지 체크..
                    // 있을 경우..레시피 이름을 변경하라는 메세지 표시..
                    if (Global.Instance.System.Recipe.JobManager[i].Jobs[j].Name == "NEW")
                    {
                        IF_Util.ShowMessageBox("NAME CHECK", $"Recipe No Name..Recipe Name Change..Please => Recipe Name : {Global.Instance.System.Recipe.JobManager[i].Jobs[j].Name}, Recipe Array Number : {i + 1}, Recipe Number : {j + 1}");
                        return true;
                    }
                }
            }

            return ret;
        }
    }
}

