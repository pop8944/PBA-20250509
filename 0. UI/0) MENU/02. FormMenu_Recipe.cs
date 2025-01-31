using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IntelligentFactory
{
    public partial class FormMenuRecipe : Form
    {
        private Global Global = Global.Instance;

        //private int originalExStyle = -1;
        //private bool enableFormLevelDoubleBuffering = true;
        public EventHandler EventUpdateControl;

        public FormMenuRecipe()
        {
            InitializeComponent();
        }

        private void FormMenuRecipe_Load(object sender, EventArgs e)
        {
            InitRecipeList();
            IF_Util.InitCombobox(this.Controls);
        }

        public void InitRecipeList()
        {
            gridRecipe.Rows.Clear();
            cbRecipe_Add_Reference.Items.Clear();

            List<string> listRecipe = new List<string>();

            string strpath = $"{Global.m_MainPJTRoot}\\RECIPE";
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

                if (i == 0)
                {
                    cbRecipe_Add_Reference.Text = strName;
                }

                string strParameterPath = $"{strpath}\\{strName}\\JOBS\\Parameter.xml";
                string strCode = "";

                if (File.Exists(strParameterPath))
                {
                    XmlTextReader xmlReader = new XmlTextReader(strParameterPath);

                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            switch (xmlReader.Name)
                            {
                                case "PbaCode": if (xmlReader.Read()) strCode = xmlReader.Value; break;
                            }
                        }
                    }

                    xmlReader.Close();
                }
                else
                {
                    strParameterPath = $"{strpath}\\{strName}\\Parameter.xml";

                    XmlTextReader xmlReader = new XmlTextReader(strParameterPath);

                    if (File.Exists(strParameterPath) == false) continue;

                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType == XmlNodeType.Element)
                        {
                            switch (xmlReader.Name)
                            {
                                case "PbaCode": if (xmlReader.Read()) strCode = xmlReader.Value; break;
                            }
                        }
                    }

                    xmlReader.Close();
                }

                Global.Instance.System.Recipe.LoadConfig();
                gridRecipe.Rows.Add((gridRecipe.Rows.Count + 1), strName, strCode);
                cbRecipe_Add_Reference.Items.Add(strName);
                DataCollection.Add(strName);
            }

            foreach (DataGridViewColumn dgvc in gridRecipe.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            tbRecipe.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbRecipe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbRecipe.AutoCompleteCustomSource = DataCollection;

            lbRecipeCurr.Text = Global.System.Recipe.Name;

            CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
        }

        private void btnRecipe_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipeName = tbRecipe_Add_Name.Text;
                string strPrevRecipe = cbRecipe_Add_Reference.Text;

                FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox("RECIPE", string.Format("Do you want to Add the Recipe ==> [{0}]?", strRecipeName));
                if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    if (strRecipeName != "")
                    {
                        //Global.System.Recipe.Name = strRecipeName;

                        string strPrevPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strPrevRecipe}";
                        string strNewPath = $"{Global.m_MainPJTRoot}\\RECIPE\\{strRecipeName}";

                        DirectoryInfo existingDir = new DirectoryInfo(strPrevPath);
                        DirectoryInfo copyDir = new DirectoryInfo(strNewPath);

                        IF_Util.SynchFolder(existingDir, copyDir);

                        Global.Recent.SaveConfig();

                        if (cbRecipe_Add_Reference.Items.Count > 0) cbRecipe_Add_Reference.SelectedIndex = 0;
                        Global.System.Notice = string.Format("Change the Recipe {0} ==> {1}", strPrevRecipe, strRecipeName);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the Recipe Name");
                    }

                    FrmMessageBox.Close();
                }
                else
                {
                    FrmMessageBox.Close();
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        //private void btnRecipe_Select_Click(object sender, EventArgs e)
        //{

        //}

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox("RECIPE", string.Format("Do you want to Save the Recipe ==> [{0}]?", lbRecipeName.Text));
        //        if (FrmMessageBox.ShowDialog() == DialogResult.OK)
        //        {
        //            Global.System.Recipe.SaveTools();
        //            Global.System.Recipe.SaveGraphic();
        //        }

        //        CLogger.Add(LOG_TYPE.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
        //    }
        //    catch (Exception ex)
        //    {
        //        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
        //        CUtil.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
        //    }
        //}

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipeName = lbRecipeName.Text;

                if (IF_Util.ShowMessageBox("RECIPE", string.Format("Do you want to Select the Recipe ==> [{0}]?", strRecipeName), FormPopUp_MessageBox.MESSAGEBOX_TYPE.OKCANCEL))
                {
                    if (strRecipeName != "")
                    {
                        string strPrevRecipe = strRecipeName;

                        Global.Recent.LastModel = strRecipeName;
                        Global.System.Recipe.Name = strRecipeName;
                        Global.Recent.szModelChangeTime = DateTime.Now.ToString("yyyyMMdd:HHmmss");
                        Global.Recent.SaveConfig();

                        Global.SeqRecipeChage.ChageRecipe(Global.System.Recipe.Name);


                        // 해당 모델의 라이브러리 잡 리드..
                        // 레시피 데이터 가져올때 task로 가동하여서 별도 정지된 현상 없애기위함..
                        // 백그라운드의 별도 TASK쓰레드 형태로 가동되므로 폼을 건드릴때는 반드시 인보크 처리 필요함..
                        Task.Run(() =>
                        {

                        });

                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Please Select the Recipe");
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
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
                if (lbRecipeName.Text == "")
                    return;

                string strRecipeName = lbRecipeName.Text;
                string strPath = Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName;

                if (strRecipeName == Global.System.Recipe.Name)
                {
                    IF_Util.ShowMessageBox("Unable to delete recipe.", "This recipe is currently applied.");
                    return;
                }

                FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox("RECIPE", string.Format("Do you want to Delete the Recipe ==> [{0}]?", strRecipeName));
                if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo di = new DirectoryInfo(strPath);
                    di.Delete(true);
                    InitRecipeList();

                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                    FrmMessageBox.Close();
                }
                else
                {
                    FrmMessageBox.Close();
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRecipeAdd_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipeName = tbRecipe_Add_Name.Text;
                string strPrevRecipe = cbRecipe_Add_Reference.Text;

                FormPopUp_MessageBox FrmMessageBox = new FormPopUp_MessageBox("RECIPE", string.Format("Do you want to Add the Recipe ==> [{0}]?", strRecipeName));
                if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    if (strRecipeName != "")
                    {
                        //Global.System.Recipe.Name = strRecipeName;

                        string strPrevPath = Global.m_MainPJTRoot + "\\RECIPE\\" + strPrevRecipe;
                        string strNewPath = Global.m_MainPJTRoot + "\\RECIPE\\" + strRecipeName;

                        if (strPrevRecipe != "")
                        {
                            DirectoryInfo existingDir = new DirectoryInfo(strPrevPath);
                            DirectoryInfo copyDir = new DirectoryInfo(strNewPath);
                            copyDir.Create();

                            IF_Util.SynchFolder(existingDir, copyDir);
                        }

                        Global.System.Recipe.Name = strRecipeName;
                        Global.Recent.LastModel = strRecipeName;
                        Global.Recent.SaveConfig();

                        Global.Instance.OnStart_Porgess();
                        Global.Notice = "Add Model Loading..";
                        // 해당 모델의 라이브러리 잡 리드..
                        // 레시피 데이터 가져올때 task로 가동하여서 별도 정지된 현상 없애기위함..
                        // 백그라운드의 별도 TASK쓰레드 형태로 가동되므로 폼을 건드릴때는 반드시 인보크 처리 필요함..

                        InitRecipeList();

                        Global.Instance.System.Recipe.LoadTools();
                        CLogger.Add(LOG.NORMAL, $"[Model : {Global.System.Recipe.Name}]LoadTools");

                        //IGlobal.Instance.System.Recipe.LoadConfig();
                        //IGlobal.Instance.System.Recipe.SettingJob();
                        Set_Invoke_Form(Global.Instance.FrmVision);
                        Global.Instance.OnEnd_Progress();

                        if (cbRecipe_Add_Reference.Items.Count > 0) cbRecipe_Add_Reference.SelectedIndex = 0;
                        Global.System.Notice = string.Format("Change the Recipe {0} ==> {1}", strPrevRecipe, strRecipeName);

                        IF_Util.ShowMessageBox("COMPLETE", "RECIPE ADD COMPLETE");
                       
                        pnRecipeAdd.Visible = false;

                    }
                    else
                    {
                        MessageBox.Show("Please Enter the Recipe Name");
                    }
                }
                else
                {
                    FrmMessageBox.Close();
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
            if (gridRecipe.SelectedRows.Count > 0)
            {
                lbRecipeName.Text = gridRecipe.SelectedRows[0].Cells[1].Value.ToString();
            }
        }

        private void tbRecipe_KeyPress(object sender, EventArgs e)
        {
            try
            {
                string strEnter = tbRecipe.Text;

                bool bPerfectFind = false;
                for (int i = 0; i < gridRecipe.Rows.Count; i++)
                {
                    string strRecipeName = gridRecipe[1, i].Value.ToString();

                    if (strRecipeName.Contains(strEnter) && bPerfectFind == false)
                    {
                        gridRecipe.Rows[i].Selected = true;
                        bPerfectFind = true;
                        gridRecipe.Rows[i].Selected = true;
                        gridRecipe.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnRecipeAdd_OK_MouseHover(object sender, EventArgs e)
        {
            btnRecipeAdd_OK.Image = Properties.Resources.Check50_MouseHover;
            btnRecipeAdd_OK.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnRecipeAdd_OK_MouseLeave(object sender, EventArgs e)
        {
            btnRecipeAdd_OK.Image = Properties.Resources.Check50_Normal;
            btnRecipeAdd_OK.ForeColor = Color.White;
        }

        private void btnSelect_MouseHover(object sender, EventArgs e)
        {
            btnSelect.Image = Properties.Resources.Check50_MouseHover;
            btnSelect.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnSelect_MouseLeave(object sender, EventArgs e)
        {
            btnSelect.Image = Properties.Resources.Check50_Normal;
            btnSelect.ForeColor = Color.White;
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.Cancel50_MouseHover;
            btnClose.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.Cancel50_Normal;
            btnClose.ForeColor = Color.White;
        }

        private void btnRecipeAdd_Cancel_MouseHover(object sender, EventArgs e)
        {
            btnRecipeAdd_Cancel.Image = Properties.Resources.Cancel50_MouseHover;
            btnRecipeAdd_Cancel.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnRecipeAdd_Cancel_MouseLeave(object sender, EventArgs e)
        {
            btnRecipeAdd_Cancel.Image = Properties.Resources.Cancel50_Normal;
            btnRecipeAdd_Cancel.ForeColor = Color.White;
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.AddNew50_MouseHover;
            btnAdd.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.Image = Properties.Resources.AddNew50_Normal;
            btnAdd.ForeColor = Color.White;
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.DeleteTrash50_MouseHover;
            btnDelete.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.Image = Properties.Resources.DeleteTrash50_Normal;
            btnDelete.ForeColor = Color.White;
        }

        private void buttonSave_MouseHover(object sender, EventArgs e)
        {
            buttonSave.Image = Properties.Resources.Save50_MouseHover;
            buttonSave.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void buttonSave_MouseLeave(object sender, EventArgs e)
        {
            buttonSave.Image = Properties.Resources.Save50_Normal;
            buttonSave.ForeColor = Color.White;
        }
    }
}