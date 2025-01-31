using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_PbaLibrary2 : Form
    {
        int nModelSelectIndex = 0;
        int nLibrarySelectIndex = 0;
        string path_Model = $"{Global.m_MainPJTRoot}\\RECIPE";

        public FormMenu_PbaLibrary2()
        {
            InitializeComponent();
        }

        private void FormMenu_PbaLibrary2_Load(object sender, EventArgs e)
        {
            try
            {
                InitList();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public bool InitList()
        {
            try
            {
                gridModel.Rows.Clear();

                List<string> list_Model = new List<string>();

                DirectoryInfo di_Model = new DirectoryInfo(path_Model);

                if (di_Model.Exists)
                {
                    DirectoryInfo[] diAry_Model = di_Model.GetDirectories();

                    for (int i = 0; i < diAry_Model.Length; i++)
                    {
                        string strModel = diAry_Model[i].Name;
                        list_Model.Add(strModel);
                    }
                }

                for (int i = 0; i < list_Model.Count; i++)
                {
                    string strName = list_Model[i];

                    gridModel.Rows.Add(strName);
                }

                SearchLibrary(path_Model);

                lbCurr.Text = Global.Instance.System.Recipe.Name;
                DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(0, 0);
                gridModel_CellClick(gridModel, e);


                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        private void SearchLibrary(string path_Model)
        {
            gridLibrary.Rows.Clear();

            List<string> list_Library = new List<string>();
            string path_Library = $"{path_Model}\\PBA_LIBRARY";

            DirectoryInfo di_Library = new DirectoryInfo(path_Library);

            if (di_Library.Exists)
            {
                DirectoryInfo[] diAry_Library = di_Library.GetDirectories();

                for (int i = 0; i < diAry_Library.Length; i++)
                {
                    string strLibrary = diAry_Library[i].Name;
                    list_Library.Add(strLibrary);
                }
            }

            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();

            for (int i = 0; i < list_Library.Count; i++)
            {
                string strName = list_Library[i];

                gridLibrary.Rows.Add(strName);
                DataCollection.Add(strName);
            }

            tbLibrary.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbLibrary.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbLibrary.AutoCompleteCustomSource = DataCollection;
        }

        // 레시피 데이터 가져오는중임을 표시함..
        bool RecipeData_Select = false;
        int RecipeCheck_Cnt = 0;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 선택된 내용이 동작..
            string strName_Model = gridModel.Rows[nModelSelectIndex].Cells[0].Value.ToString();
            string strName = gridLibrary.Rows[nLibrarySelectIndex].Cells[0].Value.ToString();

            if (IF_Util.ShowMessageBox("PBA LIBRARY", string.Format("Do you want to Select the Pba Code ==> [{0}]?", strName)))
            {
                if (strName != "")
                {
                    Global.Instance.OnStart_Porgess();
                    Global.Notice = "PBA LIBRARY LOADING...";
                    RecipeData_Select = true;
                    tmr_RecipeSaving.Enabled = true;
                    // 레시피 데이터 가져올때 task로 가동하여서 별도 정지된 현상 없애기위함..
                    // 백그라운드의 별도 TASK쓰레드 형태로 가동되므로 폼을 건드릴때는 반드시 인보크 처리 필요함..
                    Task.Run(() =>
                    {
                        string sourcePath = $"{path_Model}\\PBA_LIBRARY\\{strName}";
                        string targetPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Global.Instance.System.Recipe.Name}\\PBA_LIBRARY\\{strName}";

                        RecipeCheck_Cnt = 1;
                        if (Directory.Exists(targetPath))
                        {
                            Console.WriteLine("Library name already exists.");
                        }
                        else
                        {
                            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                            {
                                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
                            }

                            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                            {
                                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
                            }
                        }

                        RecipeCheck_Cnt = 2;
                        Global.Instance.System.Recipe.CODE = strName;
                        Global.Instance.System.Recipe.SaveConfig();
                        RecipeCheck_Cnt = 3;
                        Global.Instance.System.Recipe.SettingJob();
                        RecipeCheck_Cnt = 6;
                        Set_Invoke_Form(Global.Instance.FrmVision);
                        //IGlobal.Instance.FrmVision.InitJobs();
                        RecipeCheck_Cnt = 10;
                        RecipeData_Select = false;
                        tmr_RecipeSaving.Enabled = false;
                        Global.Instance.OnEnd_Progress();
                        //this.Close();
                        Set_Invoke_Form_Close(this);
                        CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    });
                }
                else
                {
                    IF_Util.ShowMessageBox("PBA LIBRARY", "Please Select the Library");
                }
            }
        }

        delegate void SetForm_Callback(Form _frm);
        private static void Set_Invoke_Form(Form _frm)
        {
            if (_frm.InvokeRequired)
            {
                SetForm_Callback _Invoke = new SetForm_Callback(Set_Invoke_Form);
                _frm.Invoke(_Invoke, new object[] { _frm });
            }
            else
            {
                Global.Instance.FrmVision.InitJobs();
            }
        }

        private static void Set_Invoke_Form_Close(Form _frm)
        {
            if (_frm.InvokeRequired)
            {
                SetForm_Callback _Invoke = new SetForm_Callback(Set_Invoke_Form_Close);
                _frm.Invoke(_Invoke, new object[] { _frm });
            }
            else
            {
                _frm.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 레시피 모델 선택이 아닐경우...
            if (RecipeData_Select)
            {
                IF_Util.ShowMessageBox("PBA LIBRARY", "Library Selecting..!!");
                return;
            }
            this.Close();
        }

        private void gridModel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridModel.SelectedRows.Count > 0)
            {
                nModelSelectIndex = e.RowIndex;
                lbModelName.Text = gridModel.Rows[nModelSelectIndex].Cells[0].Value.ToString();

                path_Model = $"{Global.m_MainPJTRoot}\\RECIPE\\{lbModelName.Text}";

                SearchLibrary(path_Model);
            }
        }

        private void gridLibrary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridLibrary.SelectedRows.Count > 0)
            {
                nLibrarySelectIndex = e.RowIndex;
                lbLibraryName.Text = gridLibrary.Rows[nLibrarySelectIndex].Cells[0].Value.ToString();
            }
        }

        private void tb_Model_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string strEnter = tb_Model.Text;

                bool bPerfectFind = false;
                for (int i = 0; i < gridModel.Rows.Count; i++)
                {
                    string strModelName = gridModel[1, i].Value.ToString();

                    if (strModelName.Contains(strEnter) && bPerfectFind == false)
                    {
                        gridModel.Rows[i].Selected = true;
                    }

                    if (strModelName == strEnter)
                    {
                        bPerfectFind = true;
                        gridModel.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void tbtbLibrary_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string strEnter = tbLibrary.Text;

                bool bPerfectFind = false;
                for (int i = 0; i < gridLibrary.Rows.Count; i++)
                {
                    string strLibraryName = gridLibrary[1, i].Value.ToString();

                    if (strLibraryName.Contains(strEnter) && bPerfectFind == false)
                    {
                        gridLibrary.Rows[i].Selected = true;
                    }

                    if (strLibraryName == strEnter)
                    {
                        bPerfectFind = true;
                        gridLibrary.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void FormMenu_PbaLibrary2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Instance.Frm_PBA_Library.InitList();
        }

        private void tmr_RecipeSaving_Tick(object sender, EventArgs e)
        {
            if (RecipeData_Select)
            {
                lbl_RecipeSaveDisp.Visible = true;
                pb_RecipeSaveing.Visible = true;

                if (RecipeCheck_Cnt < pb_RecipeSaveing.Maximum)
                {
                    pb_RecipeSaveing.Value = RecipeCheck_Cnt;
                }
                else
                {
                    pb_RecipeSaveing.Value = pb_RecipeSaveing.Maximum;
                }
            }
            else
            {
                lbl_RecipeSaveDisp.Visible = false;
                pb_RecipeSaveing.Visible = false;
                RecipeCheck_Cnt = 0;
            }
        }
    }
}