using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormSettings_ColorList : Form
    {
        private Global Global = Global.Instance;

        //private int originalExStyle = -1;
        //private bool enableFormLevelDoubleBuffering = true;
        public EventHandler EventUpdateControl;

        public FormSettings_ColorList()
        {
            InitializeComponent();
        }

        private void FormSettings_ColorList_Load(object sender, EventArgs e)
        {
            InitColorList();
            IF_Util.InitCombobox(this.Controls);
        }

        public void InitColorList()
        {
            try
            {
                gridColor.Rows.Clear();

                ParamInfo_Color Colors = Global.Instance.Setting.Enviroment.ColorList;
                for (int i = 0; i < Colors.ColorNodes.Count; i++)
                {
                    string name = Colors.ColorNodes[i].Name;
                    string min = $"R:{Colors.ColorNodes[i].MinR},G:{Colors.ColorNodes[i].MinG},B:{Colors.ColorNodes[i].MinB}";
                    string max = $"R:{Colors.ColorNodes[i].MaxR},G:{Colors.ColorNodes[i].MaxG},B:{Colors.ColorNodes[i].MaxB}";
                    Color color = Colors.ColorNodes[i].Color;

                    gridColor.Rows.Add(new string[] { name, min, max, color.ToString() });
                    gridColor[3, i].Style.BackColor = color;
                    gridColor[3, i].Style.SelectionBackColor = color;
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


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        ColorNode _selectedColorNode = null;
        private void gridRecipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridColor.SelectedCells.Count > 0)
                {
                    ParamInfo_Color Colors = Global.Instance.Setting.Enviroment.ColorList;
                    _selectedColorNode = Colors.ColorNodes[gridColor.SelectedCells[0].RowIndex];

                    txtName.Text = _selectedColorNode.Name;

                    txtMinR.Text = _selectedColorNode.MinR.ToString();
                    txtMinG.Text = _selectedColorNode.MinG.ToString();
                    txtMinB.Text = _selectedColorNode.MinB.ToString();

                    txtMaxR.Text = _selectedColorNode.MaxR.ToString();
                    txtMaxG.Text = _selectedColorNode.MaxG.ToString();
                    txtMaxB.Text = _selectedColorNode.MaxB.ToString();

                    lblMinColor.BackColor = _selectedColorNode.MinColor;
                    lblMaxColor.BackColor = _selectedColorNode.MaxColor;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Global.Instance.Setting.Save();
        }

        private void btnColorAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ParamInfo_Color Colors = Global.Instance.Setting.Enviroment.ColorList;

                int minR = int.Parse(txtMinR.Text);
                int minG = int.Parse(txtMinG.Text);
                int minB = int.Parse(txtMinB.Text);
                int maxR = int.Parse(txtMaxR.Text);
                int maxG = int.Parse(txtMaxG.Text);
                int maxB = int.Parse(txtMaxB.Text);

                Colors.AddColor(txtName.Text, minR, minG, minB, maxR, maxG, maxB);

                InitColorList();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void txtMaxB_KeyPress(object sender, KeyPressEventArgs e)
        {
            IF_Util.InputOnlyNumber(sender, e, false, false);
        }

        private void btnColorApply_Click(object sender, EventArgs e)
        {
            try
            {
                ParamInfo_Color Colors = Global.Instance.Setting.Enviroment.ColorList;

                int minR = int.Parse(txtMinR.Text);
                int minG = int.Parse(txtMinG.Text);
                int minB = int.Parse(txtMinB.Text);
                int maxR = int.Parse(txtMaxR.Text);
                int maxG = int.Parse(txtMaxG.Text);
                int maxB = int.Parse(txtMaxB.Text);

                if (gridColor.SelectedCells.Count > 0)
                {
                    Colors.ColorNodes[gridColor.SelectedCells[0].RowIndex] = _selectedColorNode = new ColorNode(txtName.Text, minR, minG, minB, maxR, maxG, maxB);
                }

                InitColorList();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }

        private void btnColorDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridColor.SelectedCells.Count > 0)
                {
                    ParamInfo_Color Colors = Global.Instance.Setting.Enviroment.ColorList;
                    Global.Instance.Setting.Enviroment.ColorList.ColorNodes.RemoveAt(gridColor.SelectedCells[0].RowIndex);
                }

                InitColorList();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                IF_Util.ShowMessageBox("EXCEPTION", $"[FAILED] {MethodBase.GetCurrentMethod().ReflectedType.Name}==>{MethodBase.GetCurrentMethod().Name}   Execption ==> {ex.Message}");
            }
        }
    }
}