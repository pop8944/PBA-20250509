using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_PbaLibrary : Form
    {
        int nSelectIndex = 0;

        public FormMenu_PbaLibrary()
        {
            InitializeComponent();
        }

        private void FormMenu_PbaLibrary_Load(object sender, EventArgs e)
        {
            try
            {
                InitList();
                InitRecipeList();
                // 초기 선택 내용 화면 디스플레이..
                lbName.Text = grid.Rows[nSelectIndex].Cells[0].Value.ToString();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public void InitRecipeList()
        {
            cbLibrary_Add_Reference.Items.Clear();

            cbLibrary_Add_Reference.Items.Add("-");

            List<string> listRecipe = new List<string>();

            string strpath = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY";
            DirectoryInfo di = new DirectoryInfo(strpath);
            if (di.Exists)
            {
                DirectoryInfo[] diRecipies = di.GetDirectories();

                for (int i = 0; i < diRecipies.Length; i++)
                {
                    string strRecipe = diRecipies[i].Name;
                    listRecipe.Add(strRecipe);
                }
            }
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();

            for (int i = 0; i < listRecipe.Count; i++)
            {
                string strName = listRecipe[i];

                cbLibrary_Add_Reference.Items.Add(strName);
                DataCollection.Add(strName);
            }

            cbLibrary_Add_Reference.Text = "-";
        }

        public bool InitList()
        {
            try
            {
                grid.Rows.Clear();

                List<string> list = new List<string>();

                // 경로 변경...
                string path = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY";

                DirectoryInfo di = new DirectoryInfo(path);

                if (di.Exists)
                {
                    DirectoryInfo[] di_Library = di.GetDirectories();

                    for (int i = 0; i < di_Library.Length; i++)
                    {
                        string strRecipe = di_Library[i].Name;
                        list.Add(strRecipe);
                    }
                }

                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();

                for (int i = 0; i < list.Count; i++)
                {
                    string strName = list[i];

                    grid.Rows.Add(strName);
                    DataCollection.Add(strName);
                }

                tbRecipe.AutoCompleteMode = AutoCompleteMode.Suggest;
                tbRecipe.AutoCompleteSource = AutoCompleteSource.CustomSource;
                tbRecipe.AutoCompleteCustomSource = DataCollection;

                lbCurr.Text = Global.Instance.System.Recipe.CODE;

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }
        private void btn_SelectModelLibrary_Click(object sender, EventArgs e)
        {

            if (Global.Instance.Frm_PBA_Library2 == null || !Global.Instance.Frm_PBA_Library2.Created)

            {
                Global.Instance.Frm_PBA_Library2 = new FormMenu_PbaLibrary2();
            }

            Global.Instance.Frm_PBA_Library2.BringToFront();
            Global.Instance.Frm_PBA_Library2.Owner = this;
            Global.Instance.Frm_PBA_Library2.Show();
            pnRecipeAdd.Visible = false;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // 선택된 내용이 동작..
            if (grid.RowCount < 1)
                return;

            string strName = grid.Rows[nSelectIndex].Cells[0].Value.ToString();

            if (IF_Util.ShowMessageBox("PBA LIBRARY", string.Format("Do you want to Select the Pba Code ==> [{0}]?", strName)))
            {
                if (strName != "")
                {
                    Global.Instance.OnStart_Porgess();
                    Global.Notice = "PBA LIBRARY LOADING...";
                    // 레시피 데이터 가져올때 task로 가동하여서 별도 정지된 현상 없애기위함..
                    // 백그라운드의 별도 TASK쓰레드 형태로 가동되므로 폼을 건드릴때는 반드시 인보크 처리 필요함..
                    Task.Run(() =>
                    {
                        Global.Instance.System.Recipe.CODE = strName;
                        Global.Instance.System.Recipe.SaveConfig();
                        Global.Instance.System.Recipe.SettingJob();
                        //IGlobal.Instance.FrmVision.InitJobs();
                        Set_Invoke_Form(Global.Instance.FrmVision);
                        // 크로스쓰레드 방지를 위한 인보크 델레게이트 처리..
                        Invoke_Util.Set_Invoke_Label(lbCurr, Global.Instance.System.Recipe.CODE);
                        //lbCurr.Text = IGlobal.Instance.System.Recipe.CODE;
                        Global.Instance.OnEnd_Progress();

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
        // 크로스 쓰레드 방지를 위한 인보크 델레게이트 처리..
        private static void Set_Invoke_Form(Form _frm)
        {
            if (_frm.InvokeRequired)
            {
                SetForm_Callback _Invoke = new SetForm_Callback(Set_Invoke_Form);
                _frm.Invoke(_Invoke, new object[] { _frm });
            }
            else
            {
                //Global.Instance.FrmVision.InitJobs();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.RowCount < 1)
                    return;

                // 선택된 이름이 되도록함...
                string strName = grid.Rows[nSelectIndex].Cells[0].Value.ToString();

                if (strName == Global.Instance.System.Recipe.CODE)
                {
                    IF_Util.ShowMessageBox("PBA LIBRARY", string.Format("Library being selected cannot be deleted", strName));
                    return;
                }

                string strPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{Global.Instance.System.Recipe.Name}\\PBA_LIBRARY\\{strName}";

                if (IF_Util.ShowMessageBox("PBA LIBRARY", string.Format("Do you want to Delete the Library ==> [{0}]?", strName)))
                {
                    DirectoryInfo di = new DirectoryInfo(strPath);
                    di.Delete(true);
                    InitList();

                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecipeAdd_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string strName = tbRecipe_Add_Name.Text;
                string strRefLibrary = cbLibrary_Add_Reference.Text;

                if (IF_Util.ShowMessageBox("PBA LIBRARY", string.Format("Do you want to Add the Library ==> [{0}]?", strName)))
                {
                    if (strRefLibrary == "-" || strRefLibrary == "")
                    {
                        if (strName != "")
                        {
                            string strFolderPath = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{strName}";

                            Global.Instance.System.Recipe.CODE = strName;
                            Global.Instance.System.Recipe.SaveConfig();
                            Directory.CreateDirectory(strFolderPath);

                            //2024.03.11 : 송현수
                            //Global.Instance.System.Recipe.JsonFile_Save(1, strFolderPath, true);
                            //Global.Instance.FrmVision.InitJobs();
                            InitList();
                        }
                        else
                        {
                            IF_Util.ShowMessageBox("RECIPE", "Please Enter the Library Name");
                        }
                    }
                    else
                    {
                        if (strName != "")
                        {
                            string strRefPath = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{strRefLibrary}";
                            string strNewPath = $"{Global.m_MainPJTRoot}\\PBA_LIBRARY\\{strName}";

                            DirectoryInfo existingDir = new DirectoryInfo(strRefPath);
                            DirectoryInfo copyDir = new DirectoryInfo(strNewPath);
                            copyDir.Create();

                            IF_Util.SynchFolder(existingDir, copyDir);

                            Global.Instance.System.Recipe.CODE = strName;
                            Global.Instance.System.Recipe.SaveConfig();
                            //Global.Instance.FrmVision.InitJobs();
                            InitList();
                        }
                        else
                        {
                            IF_Util.ShowMessageBox("RECIPE", "Please Enter the Library Name");
                        }
                    }
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnRecipeAdd_Cancel_Click(object sender, EventArgs e)
        {
            pnRecipeAdd.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnRecipeAdd.Visible = true;
        }

        private void gridRecipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                nSelectIndex = e.RowIndex;
                lbName.Text = grid.Rows[nSelectIndex].Cells[0].Value.ToString();
            }
        }

        private void tbRecipe_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string strEnter = tbRecipe.Text;

                bool bPerfectFind = false;
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    string strRecipeName = grid[1, i].Value.ToString();

                    if (strRecipeName.Contains(strEnter) && bPerfectFind == false)
                    {
                        grid.Rows[i].Selected = true;
                    }

                    if (strRecipeName == strEnter)
                    {
                        bPerfectFind = true;
                        grid.Rows[i].Selected = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}