using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_Settings_DefaultParameter : Form
    {
        //private IGlobal Global = IGlobal.Instance;

        //private int originalExStyle = -1;
        //private bool enableFormLevelDoubleBuffering = true;
        public EventHandler EventUpdateControl;

        private List<string> Parts = new List<string>();
        private CCogTool_PMAlign Tool = new CCogTool_PMAlign("Tool");

        public FormPopUp_Settings_DefaultParameter()
        {
            InitializeComponent();

            Parts.Add("콘덴서");
            Parts.Add("퓨즈");
            Parts.Add("커넥터");
            Parts.Add("소켓");

            propertyGrid_Jobs.SelectedObject = Tool.Tool.RunParams;
        }

        private void FormMenuRecipe_Load(object sender, EventArgs e)
        {
            try
            {
                InitEvent();
                InitPartList();
                IF_Util.InitCombobox(this.Controls);

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private bool InitEvent()
        {
            try
            {
                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        public bool InitPartList()
        {
            try
            {
                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();

                gridPart.Rows.Clear();

                for (int i = 0; i < Parts.Count; i++)
                {
                    gridPart.Rows.Add(Parts[i]);
                    DataCollection.Add(Parts[i]);
                }

                foreach (DataGridViewColumn dgvc in gridPart.Columns)
                {
                    dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                tbPartName.AutoCompleteMode = AutoCompleteMode.Suggest;
                tbPartName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                tbPartName.AutoCompleteCustomSource = DataCollection;

                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }

            return true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
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
            this.Close();
        }

        private void gridRecipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridPart.SelectedRows.Count > 0)
            {
            }
        }

        private void tbRecipe_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string strEnter = tbPartName.Text;

                for (int i = 0; i < gridPart.Rows.Count; i++)
                {
                    string strRecipeName = gridPart[1, i].Value.ToString();

                    if (strRecipeName.Contains(strEnter))
                    {
                        gridPart.Rows[i].Selected = true;
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