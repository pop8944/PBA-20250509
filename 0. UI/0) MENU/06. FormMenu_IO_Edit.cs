using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_IO_Edit : Form
    {
        int nSelect_In_Index = 0;
        int nSelect_Out_Index = 0;
        // 어드레스 비트 번호 바꾼것 확인 플래그..
        bool InPut_ChangeAddress = false;
        bool OutPut_ChangeAddress = false;

        // 비트의 IO INDEX를 현장에 맞춰서 사용하기 위해 해당 폼 추가..
        public FormMenu_IO_Edit()
        {
            InitializeComponent();
        }

        private void FormMenu_IO_Edit_Load(object sender, EventArgs e)
        {
            Grid_Disp();
        }

        // 현재 사용하는 IO의 그리드 뷰 드로잉..
        // 해당 부분에 비트가 추가되면 내용 추가 필요..
        private void Grid_Disp()
        {
            gridInput.Rows.Clear();
            gridOutput.Rows.Clear();

            int in_maxcnt = Global.Instance.Device.DIO_BD.IO_DATA.DI_MAXCNT;
            for (int i = 0; i < in_maxcnt; i++)
            {
                string addres = Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[i].IO_ADRESS;
                string name = Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[i].IO_NAME;

                if (Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[i].IO_NAME == CDIO_BITNAME.INSP_START)
                {
                    gridInput.Rows.Add(new string[] { addres, name });
                }
            }

            gridInput.CurrentCell = gridInput.Rows[nSelect_In_Index].Cells[0];
            txt_Input_Address.Text = gridInput.Rows[nSelect_In_Index].Cells[0].Value.ToString();
            lbl_Input_Name.Text = gridInput.Rows[nSelect_In_Index].Cells[1].Value.ToString();

            int out_maxcnt = Global.Instance.Device.DIO_BD.IO_DATA.DO_MAXCNT;
            for (int i = 0; i < out_maxcnt; i++)
            {
                string addres = Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_ADRESS;
                string name = Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_NAME;

                if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_NAME == CDIO_BITNAME.RESULT_NG)
                {
                    gridOutput.Rows.Add(new string[] { addres, name });
                }
                else if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_NAME == CDIO_BITNAME.RESULT_OK)
                {
                    gridOutput.Rows.Add(new string[] { addres, name });
                }
            }

            gridOutput.CurrentCell = gridOutput.Rows[nSelect_Out_Index].Cells[0];
            txt_Output_Address.Text = gridOutput.Rows[nSelect_Out_Index].Cells[0].Value.ToString();
            lbl_Output_Name.Text = gridOutput.Rows[nSelect_Out_Index].Cells[1].Value.ToString();
        }

        private void gridInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nSelect_In_Index = e.RowIndex;
            txt_Input_Address.Text = gridInput.Rows[nSelect_In_Index].Cells[0].Value.ToString();
            lbl_Input_Name.Text = gridInput.Rows[nSelect_In_Index].Cells[1].Value.ToString();
        }

        private void gridOutput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nSelect_Out_Index = e.RowIndex;
            txt_Output_Address.Text = gridOutput.Rows[nSelect_Out_Index].Cells[0].Value.ToString();
            lbl_Output_Name.Text = gridOutput.Rows[nSelect_Out_Index].Cells[1].Value.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (IF_Util.ShowMessageBox("SAVE", "Do you want to Bit Data Apply?"))
            {
                if (BIT_DATA_CHECK())
                {
                    BIT_DATA_SET();
                    // INI에 데이터 저장...
                    Global.Instance.Device.DIO_BD.IO_DATA.Config_Save();
                    // 데이터 재 디스플레이..
                    Grid_Disp();
                    Global.Instance.Device.DIO_BD.IO_DATA.IO_Edit = true;

                    // 플래그 초기화
                    InPut_ChangeAddress = false;
                    OutPut_ChangeAddress = false;
                }
            }
        }

        private bool BIT_DATA_CHECK()
        {
            // 해당 어드레스 값이 기존 어드레스 넘버랑 겹치는지 체크...
            // 값이 바뀐것을 확인
            int index = int.Parse(txt_Input_Address.Text);

            if (InPut_ChangeAddress)
            {
                if (Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[nSelect_In_Index].IO_ADRESS != txt_Input_Address.Text)
                {
                    if (Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[index].IO_NAME == CDIO_BITNAME.INSP_START)
                    {
                        IF_Util.ShowMessageBox("Text KeyIn Check", "No Adress!! Another Adress Please Key-In!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                        txt_Input_Address.Text = gridInput.Rows[nSelect_In_Index].Cells[0].Value.ToString();
                        return false;
                    }
                }
            }

            index = int.Parse(txt_Output_Address.Text);

            if (OutPut_ChangeAddress)
            {
                if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[nSelect_Out_Index].IO_ADRESS != txt_Output_Address.Text)
                {
                    if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[index].IO_NAME == CDIO_BITNAME.RESULT_OK ||
                        Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[index].IO_NAME == CDIO_BITNAME.RESULT_NG)
                    {
                        IF_Util.ShowMessageBox("Text KeyIn Check", "No Adress!! Another Adress Please Key-In!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
                        txt_Output_Address.Text = gridOutput.Rows[nSelect_Out_Index].Cells[0].Value.ToString();
                        return false;
                    }
                }
            }

            return true;
        }

        private void BIT_DATA_SET()
        {
            int address = int.Parse(txt_Input_Address.Text);
            string name = lbl_Input_Name.Text;
            int max = Global.Instance.Device.DIO_BD.IO_DATA.DI_MAXCNT;

            for (int i = 0; i < max; i++)
            {
                if (i == address)
                {
                    Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[i].IO_NAME = name;
                }
                else
                {
                    if (Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[i].IO_NAME == name)
                    {
                        Global.Instance.Device.DIO_BD.IO_DATA.list_DI_Data[i].IO_NAME = $"IN_{i:00}";
                    }
                }
            }

            address = int.Parse(txt_Output_Address.Text);
            name = lbl_Output_Name.Text;
            max = Global.Instance.Device.DIO_BD.IO_DATA.DO_MAXCNT;

            for (int i = 0; i < max; i++)
            {
                if (i == address)
                {
                    Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_NAME = name;
                }
                else
                {
                    if (Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_NAME == name)
                    {
                        Global.Instance.Device.DIO_BD.IO_DATA.list_DO_Data[i].IO_NAME = $"OUT_{i:00}";
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_InputKeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자값만 입력되도록 인터락 추가(백스페이스는 입력되도록함)
            // 엔터키는 입력되도록함.
            if ((char.IsDigit(e.KeyChar) == false && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar(Keys.Enter) && e.KeyChar != Convert.ToChar('.')))
            {
                e.Handled = true;
                IF_Util.ShowMessageBox("Text KeyIn Check", "Only Number key-in Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
            }
            else
            {
                InPut_ChangeAddress = true;
            }
        }

        private void txt_OutputKeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자값만 입력되도록 인터락 추가(백스페이스는 입력되도록함)
            // 엔터키는 입력되도록함.
            if ((char.IsDigit(e.KeyChar) == false && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar(Keys.Enter) && e.KeyChar != Convert.ToChar('.')))
            {
                e.Handled = true;
                IF_Util.ShowMessageBox("Text KeyIn Check", "Only Number key-in Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);
            }
            else
            {
                OutPut_ChangeAddress = true;
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            string str = txt.Text;

            // 0또는 1일경우...리턴...
            if (str == "0" || str == "1") return;

            // 0 ~ 15까지의 값만 입력 가능하도록함...
            if (str != "00" && str != "01" && str != "02" && str != "03" && str != "04" && str != "05" && str != "06" && str != "07" &&
                str != "08" && str != "09" && str != "10" && str != "11" && str != "12" && str != "13" && str != "14" && str != "15")
            {
                IF_Util.ShowMessageBox("Text KeyIn Check", "Number 00 ~ 15 Key In Please!!", FormPopUp_MessageBox.MESSAGEBOX_TYPE.NOMAL);

                if (txt.Name == "txt_Input_Address")
                {
                    txt.Text = gridInput.Rows[nSelect_In_Index].Cells[0].Value.ToString();
                }
                else
                {
                    txt.Text = gridOutput.Rows[nSelect_Out_Index].Cells[0].Value.ToString();
                }
            }
        }

        private void btnApply_MouseHover(object sender, EventArgs e)
        {
            btnApply.Image = Properties.Resources.Check50_MouseHover;
            btnApply.ForeColor = Color.FromArgb(255, 196, 255, 14);
        }

        private void btnApply_MouseLeave(object sender, EventArgs e)
        {
            btnApply.Image = Properties.Resources.Check50_Normal;
            btnApply.ForeColor = Color.White;
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
    }
}
