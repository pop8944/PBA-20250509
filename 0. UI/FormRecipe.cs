using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.IO;

using OpenCvSharp;

using MetroFramework.Forms;


namespace IntelligentFactory
{
    public partial class FormRecipe : MetroForm
    {
        private IGlobal Global = IGlobal.Instance;

        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;
        public EventHandler EventUpdateControl;

        public List<string> tmpModelCode = new List<string>();

        public FormRecipe()
        {
            InitializeComponent();
        }

        private void FormRecipe_Load(object sender, EventArgs e)
        {
            try
            {
                InitEvent();                                

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;

                CreateParams cp = base.CreateParams;
                if (enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;

                return cp;
            }
        }

        private bool InitEvent()
        {
            try
            {
                Global.System.EventChangedRecipe += OnChangedRecipe;
                EventUpdateControl += OnUpdateControl;

                OnChangedRecipe(null, null);

                if(EventUpdateControl != null)
                {
                    EventUpdateControl(null, null);
                }

                cbRecipeRefList.SelectedIndex = 0;
                cbSubRecipeRefList.SelectedIndex = 0;

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }

        private void OnChangedRecipe(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnChangedRecipe(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
            else
            {                
                try
                {
                    // string[] strRecipeArr = Global.System.Recipe.Name.Split('.');                    
                    //lbModelName.Text = strRecipeArr[0];
                    //lbModelNo.Text = Global.System.Recipe.ModelNo.ToString();

                    lbModelName.Text = Global.System.Recipe.Name;
                    lbLastUpdateTime.Text = Global.System.LastRecipeUpdateTime;


                    InitRecipeList();
                    InitModelCodeList();

                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }



        private void OnUpdateControl(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        OnUpdateControl(sender, e);
                    }));
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
            else
            {
               try
                {
                    CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                }
                catch (Exception ex)
                {
                    CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                }
            }
        }


        public bool InitRecipeList()
        {
            try
            {
                dgvRecipeList.Rows.Clear();
                cbRecipeRefList.Items.Clear();

                List<string> listRecipe = new List<string>();
                List<string> listSubRecipe = new List<string>();

                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\RECIPE");
                if (di.Exists)
                {
                    DirectoryInfo[] diRecipies = di.GetDirectories();

                    for (int i = 0; i < diRecipies.Length; i++)
                    {
                        string strRecipe = diRecipies[i].Name;
                        listRecipe.Add(strRecipe);
                    }
                }

                for (int i = 0; i < listRecipe.Count; i++)
                {
                    string strName = listRecipe[i];

                    if (i == 0)
                    {
                        cbRecipeRefList.Text = strName;
                    }
                    //string[] strArr = strName.Split('.');
                    //string strModelNo = strArr[0];
                    //string strRecipeName = strArr[1];
                    //dgvRecipeList.Rows.Add(strModelNo, strRecipeName);
                    dgvRecipeList.Rows.Add(strName);
                    cbRecipeRefList.Items.Add(strName);
                }

                DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\RECIPE\\" + Global.System.Recipe.Name +"\\SubRECIPE\\");
                if (dir.Exists)
                {
                    DirectoryInfo[] diRecipies = dir.GetDirectories();

                    for (int i = 0; i < diRecipies.Length; i++)
                    {
                        string strRecipe = diRecipies[i].Name;
                        listSubRecipe.Add(strRecipe);
                    }
                }

                dgvSubRecipeList.Rows.Clear();
                cbSubRecipeRefList.Items.Clear();

                for (int i = 0; i < listSubRecipe.Count; i++)
                {
                    string strName = listSubRecipe[i];

                    if (i == 0)
                    {
                        cbSubRecipeRefList.Text = strName;
                    }
                    //string[] strArr = strName.Split('.');
                    //string strModelNo = strArr[0];
                    //string strRecipeName = strArr[1];
                    //dgvRecipeList.Rows.Add(strModelNo, strRecipeName);
                    dgvSubRecipeList.Rows.Add(strName);
                    cbSubRecipeRefList.Items.Add(strName);
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }

        public bool InitModelCodeList()
        {
            try
            {
                Grid_ModelCODE.Rows.Clear();

                List<string> tmpModelCode = new List<string>();

                //tmpModelCode = CVisionTools.Load_ModelCode_lst(Global.System.Recipe.Name);


                if (tmpModelCode != null)
                {
                    for (int i = 0; i < tmpModelCode.Count; i++)
                    {
                        Grid_ModelCODE.Rows.Add(new object[] { tmpModelCode[i] });
                    }
                }

               



                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }

            return true;
        }

        //private void btnNewRecipe_Click(object sender, EventArgs e)
        //{
        //    pnRecipeNew.Visible = true;
        //}

        //private void btnNewRecipeCancel_Click(object sender, EventArgs e)
        //{
        //    pnRecipeNew.Visible = false;
        //}

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = dgvRecipeList.CurrentRow.Index;
                string strRecipeName = dgvRecipeList.Rows[nIndex].Cells[0].Value.ToString() + "." + dgvRecipeList.Rows[nIndex].Cells[1].Value.ToString();
                string strPath = Application.StartupPath + "\\RECIPE\\" + strRecipeName;

                if (strRecipeName == Global.System.Recipe.Name)
                {
                    CUtil.ShowMessageBox("Unable to delete recipe.", "This recipe is currently applied.");
                    return;
                }

                FormMessageBox FrmMessageBox = new FormMessageBox("Select the Recipe", string.Format("Do you want to Delete the Recipe ==> [{0}]?", strRecipeName));
                if(FrmMessageBox.ShowDialog() == DialogResult.OK)
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
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnNewRecipeCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string strRecipeName = tbRecipeNewName.Text;
                string strPrevRecipe = cbRecipeRefList.Text;

                //string strPLCNo = tbRecipeNewNo.Text;

                FormMessageBox FrmMessageBox = new FormMessageBox("Add the Recipe", string.Format("Do you want to Add the Recipe ==> [{0}]?", strRecipeName));
                if(FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    if (strRecipeName != "")
                    {
                        //Global.System.Recipe.Name = string.Format("{0}.{1}", strPLCNo, strRecipeName);

                        Global.System.Recipe.Name = strRecipeName;

                        string strPrevPath = Application.StartupPath + "\\RECIPE\\" + strPrevRecipe;
                        string strNewPath = Application.StartupPath + "\\RECIPE\\" + Global.System.Recipe.Name;
                        

                        DirectoryInfo existingDir = new DirectoryInfo(strPrevPath);
                        DirectoryInfo copyDir = new DirectoryInfo(strNewPath);

                        SynchFolder(existingDir, copyDir);

                        


                        Global.System.LastRecipe = Global.System.Recipe.Name;

                        Global.System.SaveConfig();

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
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            

        }

        /// <summary>
        /// 원본/대상 폴더의 파일들을 비교하여 데이터를 backup합니다.
        /// </summary>
        /// <param name="existingDir"></param>
        /// <param name="copyDir"></param>
        private void SynchFolder(DirectoryInfo existingDir, DirectoryInfo copyDir)
        {
            try
            {
                //if(!copyDir.Exists)
                //{
                //    copyDir.Create();
                //}

                // 각각의 폴더에 있는 파일을 얻습니다.
                FileInfo[] existingFiles = existingDir.GetFiles(); // 원본
                FileInfo[] copyFiles = copyDir.GetFiles(); // 대상 파일

                bool findFile = false;
                int nIndex = 0;

                #region 파일 비교
                foreach (var existingFile in existingFiles)
                {
                    findFile = false;
                    nIndex = -1;
                    foreach (var copyFile in copyFiles)
                    {
                        nIndex++;

                        if (copyFile == null)
                        {
                            continue;
                        }

                        // 두 파일의 이름이 같다면
                        if (existingFile.Name == copyFile.Name)
                        {
                            findFile = true;

                            // 두 파일의 마지막 쓰기 시간이 틀리다면
                            if (existingFile.LastWriteTime != copyFile.LastWriteTime)
                            {
                                try
                                {
                                    if (existingFile.LastWriteTime > copyFile.LastWriteTime)
                                    {
                                        File.Copy(existingFile.FullName, copyFile.FullName, true);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                copyFiles[nIndex] = null;

                                break;
                            }
                        }
                    }

                    // 원본에는 있는데, 대상 폴더에 없는 경우에는 무조건 복사
                    if (!findFile)
                    {
                        try
                        {
                            String path = copyDir.FullName + "\\" + existingFile.Name;
                            existingFile.CopyTo(path);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                #endregion

                #region 폴더 비교
                DirectoryInfo[] existingFolders = existingDir.GetDirectories();
                DirectoryInfo[] copyFolders = copyDir.GetDirectories();

                foreach (var existingFolder in existingFolders)
                {
                    findFile = false;
                    nIndex = -1;

                    foreach (var copyFolder in copyFolders)
                    {
                        nIndex++;

                        if (copyFolder == null)
                        {
                            continue;
                        }

                        // 폴더가 있다면
                        if (existingFolder.Name == copyFolder.Name)
                        {
                            findFile = true;

                            // 재귀함수를 호출하여 폴더안에 폴더를 검사
                            // 재귀함수이기에 첫번째부터 진행하였던 파일들을 다시 검사
                            // 매개변수는 foreach문으로 처음에 가져왔던 폴더들로 다시 진행
                            SynchFolder(existingFolder, copyFolder);

                            copyFolders[nIndex] = null;

                            //break;
                        }
                    }

                    // 원본에는 있는데, 대상 폴더에 없는 경우에는 무조건 복사
                    if (!findFile)
                    {
                        try
                        {
                            string path = copyDir.FullName + "\\" + existingFolder.Name;
                            Directory.CreateDirectory(path);
                            SynchFolder(existingFolder, new DirectoryInfo(path));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            #endregion
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnRecipeBackupView.Visible = true;
        }

        private void btnOriginalPath_Click(object sender, EventArgs e)
        {
            OpenFolderPath(out string strPath);
            
            if(strPath == "")
            {
                return;
            }

            tbRecipeNewName.Text = strPath;
        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            OpenFolderPath(out string strPath);

            if(strPath == "")
            {
                return;
            }

            tbBackupPath.Text = strPath;
        }

        private bool OpenFolderPath(out string strdirPath)
        {
            strdirPath = "";
            try
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        strdirPath = fbd.SelectedPath;
                    }
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
                return true;
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
                return false;
            }
        }

        public int m_nSelectedIndex = 0;
        public int m_nSubSelectedIndex = 0;
        private void dgvRecipeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                m_nSelectedIndex = dgvRecipeList.CurrentRow.Index;
                //string strRecipeName = dgvRecipeList.Rows[m_nSelectedIndex].Cells[0].Value.ToString() + "." + dgvRecipeList.Rows[m_nSelectedIndex].Cells[1].Value.ToString();

                //string[] strArr = strRecipeName.Split('.');

                string strRecipeName = dgvRecipeList.Rows[m_nSelectedIndex].Cells[0].Value.ToString();

                lbSelectedModel.Text = strRecipeName;

                List<string> listRecipe = new List<string>();

                DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\RECIPE\\" + strRecipeName +"\\SubRECIPE");
                if (di.Exists)
                {
                    DirectoryInfo[] diRecipies = di.GetDirectories();

                    for (int i = 0; i < diRecipies.Length; i++)
                    {
                        string strRecipe = diRecipies[i].Name;
                        listRecipe.Add(strRecipe);
                    }
                }

                dgvSubRecipeList.Rows.Clear();
                cbSubRecipeRefList.Items.Clear();

                for (int i = 0; i < listRecipe.Count; i++)
                {
                    string strName = listRecipe[i];

                    if (i == 0)
                    {
                        cbSubRecipeRefList.Text = strName;
                    }
                   
                    dgvSubRecipeList.Rows.Add(strName);
                    cbSubRecipeRefList.Items.Add(strName);
                   
                }

                Grid_ModelCODE.Rows.Clear();

                List<string> tmpModelCode = new List<string>();

                //tmpModelCode = CVisionTools.Load_ModelCode_lst(strRecipeName);

                if (tmpModelCode != null)
                {
                    for (int i = 0; i < tmpModelCode.Count; i++)
                    {
                        Grid_ModelCODE.Rows.Add(new object[] { tmpModelCode[i] });
                    }
                }

                //Logger.WriteLog(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }


        private void btnSpecSave_Click(object sender, EventArgs e)
        {
            try
            {
                FormMessageBox FrmMessageBox = new FormMessageBox(string.Format("Select the Recipe {0}", Global.System.Recipe.Name), string.Format("Do you want to Save the Spec?"));

                if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    if (EventUpdateControl != null)
                    {
                        EventUpdateControl(null, null);
                    }
                }
                FrmMessageBox.Close();

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void tbRecipe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
                e.KeyChar = Convert.ToChar(0);
        }

        //private void btnRecipeNew_Click(object sender, EventArgs e)
        //{
        //    pnRecipeNew.Visible = true;
        //}

        private void btnRecipeDel_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = dgvRecipeList.CurrentRow.Index;
                //string strRecipeName = dgvRecipeList.Rows[nIndex].Cells[0].Value.ToString() + "." + dgvRecipeList.Rows[nIndex].Cells[1].Value.ToString();

                string strRecipeName = dgvRecipeList.Rows[nIndex].Cells[0].Value.ToString();
                string strPath = Application.StartupPath + "\\RECIPE\\" + strRecipeName;

                if (strRecipeName == Global.System.Recipe.Name)
                {
                    CUtil.ShowMessageBox("Unable to delete recipe.", "This recipe is currently applied.");
                    return;
                }

                FormMessageBox FrmMessageBox = new FormMessageBox("Select the Recipe", string.Format("Do you want to Delete the Recipe ==> [{0}]?", strRecipeName));
                if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                {
                    DirectoryInfo di = new DirectoryInfo(strPath);
                    di.Delete(true);
                    InitRecipeList();
                    InitModelCodeList();

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
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnRecipeSelect_Click(object sender, EventArgs e)
        {
            try
            {
                
                FormAuthorization_DoubleCheck FrmAuthorization_DoubleCheck = new FormAuthorization_DoubleCheck();
                if (FrmAuthorization_DoubleCheck.ShowDialog() == DialogResult.OK)
                {
                    string strRecipeName = "";
                    string strSubRecipeName = "";
                    //strRecipeName = dgvRecipeList[0, m_nSelectedIndex].Value.ToString() + "." + dgvRecipeList[1, m_nSelectedIndex].Value.ToString();

                    strRecipeName = dgvRecipeList[0, m_nSelectedIndex].Value.ToString();

                    strSubRecipeName = dgvSubRecipeList[0, m_nSubSelectedIndex].Value.ToString();

                    FormMessageBox FrmMessageBox = new FormMessageBox("Select the Recipe", string.Format("Do you want to Select the Recipe ==> [{0}]?", strRecipeName));

                    if (FrmMessageBox.ShowDialog() == DialogResult.OK)
                    {
                        if (strRecipeName != "")
                        {
                            string strPrevRecipe = Global.System.Recipe.Name;
                            string ModiyRecipe = lbSelectedModel.Text;

                            

                            Global.System.LastRecipe = strRecipeName;
                            Global.System.Recipe.Name = strRecipeName;

                            Global.System.LastSubRecipe = strSubRecipeName;


                            InitModelCodeList();

                            Global.System.SaveConfig();
                            
                           



                            Global.System.Notice = string.Format("Change the Recipe {0} ==> {1}", strPrevRecipe, strRecipeName);
                            
                        }
                        else
                        {
                            MessageBox.Show("Please Select the Recipe");
                        }
                        FrmMessageBox.Close();
                    }
                    else
                    {
                        FrmMessageBox.Close();
                    }
                }

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void tbRecipeNewName_Click(object sender, EventArgs e)
        {

        }

        private void dgvRecipeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModelCodeADD_Click(object sender, EventArgs e)
        {
            try
            {
                ////string str_ModelCode = tbModelCode.Text;
                //string tmpRecipe = lbSelectedModel.Text;

                //if(tmpRecipe != null && tmpRecipe != "-")
                //{
                //    tmpModelCode.Clear();

                //    tmpModelCode = CVisionTools.Load_ModelCode_lst(tmpRecipe);

                //    if(tmpModelCode != null)
                //    {
                //        // 동일한 이름이 있는지 확인
                //        for (int i = 0; i < tmpModelCode.Count; i++)
                //        {
                //            if (string.Equals(tmpModelCode[i], str_ModelCode, StringComparison.OrdinalIgnoreCase))
                //            {
                //                CUtil.ShowMessageBox("NOTICE", "MODEL CODE ALREADY EXISTS");
                //                return;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        tmpModelCode = new List<string>();
                //    }
                    
                //    tmpModelCode.Add(str_ModelCode);

                //    CVisionTools.Save_ModelCode(tmpRecipe, tmpModelCode);

                //    Grid_ModelCODE.Rows.Clear();
                //    for (int i = 0; i < tmpModelCode.Count; i++)
                //    {

                //        Grid_ModelCODE.Rows.Add(new object[] { tmpModelCode[i] });
                //    }



                //    Grid_ModelCODE.Rows[tmpModelCode.Count - 1].Selected = true;
                //    Grid_ModelCODE.Rows[tmpModelCode.Count - 1].Cells[0].Selected = true;
                //}

                

                


            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        

        private void btnModelCodeDELETE_Click(object sender, EventArgs e)
        {
        }

        private void btnModelCodeSAVE_Click(object sender, EventArgs e)
        {
            try
            {
                string tmpRecipe = lbSelectedModel.Text;

                if (tmpRecipe != null && tmpRecipe != "-")
                {
                   
                    

                }   
                
            }
            catch (Exception ex)
            {

                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {

        }

        private void btnNewSubRecipeCreate_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        string strSelectMainRecipe = lbSelectedModel.Text;
        //        string strSubRecipe = tbSubRecipeNewName.Text;
        //        string strRecipeName = tbSubRecipeNewName.Text;
        //        string strPrevRecipe = cbSubRecipeRefList.Text;


        //        if(strSelectMainRecipe != "" && strSelectMainRecipe != null && strSelectMainRecipe != "-")
        //        {
        //            FormMessageBox FrmMessageBox = new FormMessageBox("Add the Recipe", string.Format("Do you want to Add the Recipe ==> [{0}]?", strSubRecipe));
        //            if (FrmMessageBox.ShowDialog() == DialogResult.OK)
        //            {
        //                if (strRecipeName != "")
        //                {
        //                    // 동일한 이름이 있는지 확인
        //                    for (int i = 0; i < Global.System.Recipe.SubModel.Count; i++)
        //                    {
        //                        if (string.Equals(Global.System.Recipe.SubModel[i], strSubRecipe, StringComparison.OrdinalIgnoreCase))
        //                        {
        //                            CUtil.ShowMessageBox("NOTICE", "MODEL CODE ALREADY EXISTS");
        //                            return;
        //                        }
        //                    }
        //                    //Global.System.Recipe.SubModel.Add(strSubRecipe);

        //                    //UpdateSubModel();

        //                    //CVisionTools.Save_SubRecipeList(strSelectMainRecipe, Global.System.Recipe.SubModel);

        //                    //Global.System.SubRecipe.Name = strRecipeName;

        //                    Global.System.Recipe.Name = strSelectMainRecipe;
        //                    Global.System.Recipe.SubName = strRecipeName;

        //                    string strPrevPath = Application.StartupPath + "\\RECIPE\\" + strSelectMainRecipe + "\\SubRECIPE\\" + strPrevRecipe;
        //                    string strNewPath = Application.StartupPath + "\\RECIPE\\" + strSelectMainRecipe + "\\SubRECIPE\\" + Global.System.Recipe.SubName;

        //                    DirectoryInfo existingDir = new DirectoryInfo(strPrevPath);
        //                    DirectoryInfo copyDir = new DirectoryInfo(strNewPath);

        //                    SynchFolder(existingDir, copyDir);

        //                    Global.System.LastRecipe = strSelectMainRecipe;

        //                    Global.System.LastSubRecipe = Global.System.Recipe.SubName;

        //                    Global.System.SaveConfig();

        //                    //Global.System.Notice = string.Format("Change the Recipe {0} ==> {1}", strPrevRecipe, strRecipeName);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Please Enter the Recipe Name");
        //                }
        //                FrmMessageBox.Close();
        //            }
        //            else
        //            {
        //                FrmMessageBox.Close();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please Select Main Recipe");
        //        }

                


        //    }
        //    catch (Exception ex)
        //    {

        //        CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
        //    }
        }


        private void dgvSubRecipeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSubRecipeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                m_nSubSelectedIndex = dgvSubRecipeList.CurrentRow.Index;

                string strMainRecipeName = lbSelectedModel.Text;
                string strRecipeName = dgvSubRecipeList.Rows[m_nSubSelectedIndex].Cells[0].Value.ToString();

                lbSelectedSubModel.Text = strRecipeName;

                Grid_ModelCODE.Rows.Clear();

                List<string> tmpModelCode = new List<string>();

                if(strMainRecipeName != null && strMainRecipeName != "" && strMainRecipeName != "-")
                {
                    if (tmpModelCode != null)
                    {
                        for (int i = 0; i < tmpModelCode.Count; i++)
                        {
                            Grid_ModelCODE.Rows.Add(new object[] { tmpModelCode[i] });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Select Main Recipe");
                }

               

                
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}

