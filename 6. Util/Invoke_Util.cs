using System.Collections.Generic;
using System.Windows.Forms;

namespace IntelligentFactory
{
    // 크로스 쓰레드 방지를 위한 쓰레드 사용시 컨트롤 접근 클래스 
    public static class Invoke_Util
    {
        delegate void SetTextboxInvoke_Callback(TextBox _txtbox, string _str_text);
        delegate void SetLabelColorInvoke_Callback(Label _txtbox, System.Drawing.Color _color, string _str_text);
        delegate void SetLabelInvoke_Callback(Label _txtbox, string _str_text);
        delegate void SetButtonInvoke_Callback(Button _btn, System.Drawing.Color _color, string _str_text);
        delegate void SetListBox_Callback(ListBox _listbox, string _str_text);
        delegate void SetPictureBox_Callback(PictureBox _picturebox, System.Drawing.Bitmap _image);
        delegate void SetFrom_Callback(Form _form);
        delegate void SetPanel_Callback(Panel _pnl, Form _frm);
        delegate void SetFromShow_Callback(Form _frm);
        delegate void SetDataGridViewInvoke_Callback(DataGridView _datagridview, List<object[]> _obj_Value);
        public static void Set_Invoke_FromShow(Form _frm)
        {
            if (_frm.InvokeRequired)
            {
                SetFromShow_Callback _Invoke = new SetFromShow_Callback(Set_Invoke_FromShow);
                _frm.Invoke(_Invoke, new object[] { _frm });
            }
            else
            {
                _frm.Show();
            }
        }

        public static void Set_Invoke_FromHide(Form _frm)
        {
            if (_frm.InvokeRequired)
            {
                SetFromShow_Callback _Invoke = new SetFromShow_Callback(Set_Invoke_FromHide);
                _frm.Invoke(_Invoke, new object[] { _frm });
            }
            else
            {
                _frm.Hide();
            }
        }

        public static void Set_Invoke_Panel(Panel _pnl, Form _frm)
        {
            if (_pnl.InvokeRequired)
            {
                SetPanel_Callback _Invoke = new SetPanel_Callback(Set_Invoke_Panel);
                _pnl.Invoke(_Invoke, new object[] { _pnl, _frm });
            }
            else
            {
                //pnMDI.Controls.Clear();
                _frm.FormBorderStyle = FormBorderStyle.None;
                _frm.TopLevel = false;
                _pnl.Controls.Add(_frm);
                _frm.Dock = DockStyle.Fill;
                _frm.Show();
            }
        }

        public static void Set_Invoke_PictureBox(PictureBox _control, System.Drawing.Bitmap _image)
        {
            if (_control.InvokeRequired)
            {
                SetPictureBox_Callback _Invoke = new SetPictureBox_Callback(Set_Invoke_PictureBox);
                _control.Invoke(_Invoke, new object[] { _control, _image });
            }
            else
            {
                _control.Image = _image;
            }
        }

        public static void Set_Invoke_Listbox(ListBox _control, string _str_text)
        {
            string strTemp = "";

            if (_control.InvokeRequired)
            {
                SetListBox_Callback _invoke = new SetListBox_Callback(Set_Invoke_Listbox);
                _control.Invoke(_invoke, new object[] { _control, _str_text });
            }
            else
            {
                strTemp = System.DateTime.Now.ToString("[HH:mm:ss.fff] ") + _str_text;

                _control.Items.Add(strTemp);

                if (_control.Items.Count > 100)
                {
                    _control.SelectedIndex = 0;
                    _control.Items.Remove(_control.SelectedItem);
                }

                _control.SelectedIndex = _control.Items.Count - 1;
            }
        }


        public static void Set_Invoke_Button(Button _control, System.Drawing.Color _color, string _txt)
        {
            if (_control.InvokeRequired)
            {
                SetButtonInvoke_Callback _invoke = new SetButtonInvoke_Callback(Set_Invoke_Button);
                _control.Invoke(_invoke, new object[] { _control, _color, _txt });
            }
            else
            {
                _control.BackColor = _color;
                _control.Text = _txt;
            }
        }

        public static void Set_Invoke_TextBox(TextBox _control, string _txt)
        {
            if (_control.InvokeRequired)
            {
                SetTextboxInvoke_Callback _invoke = new SetTextboxInvoke_Callback(Set_Invoke_TextBox);
                _control.Invoke(_invoke, new object[] { _control, _txt });
            }
            else
            {
                _control.Text = _txt;
            }
        }

        public static void Set_Invoke_Color_Label(Label _control, System.Drawing.Color _color, string _txt)
        {
            if (_control.InvokeRequired)
            {
                SetLabelColorInvoke_Callback _invoke = new SetLabelColorInvoke_Callback(Set_Invoke_Color_Label);
                _control.Invoke(_invoke, new object[] { _control, _color, _txt });
            }
            else
            {
                _control.BackColor = _color;
                _control.Text = _txt;
            }
        }

        public static void Set_Invoke_Label(Label _control, string _txt)
        {
            if (_control.InvokeRequired)
            {
                SetLabelInvoke_Callback _invoke = new SetLabelInvoke_Callback(Set_Invoke_Label);
                _control.Invoke(_invoke, new object[] { _control, _txt });
            }
            else
            {
                _control.Text = _txt;
            }
        }

        public static void Set_Invoke_DataGridView(DataGridView _control, List<object[]> _values)
        {
            if (_control.InvokeRequired)
            {
                SetDataGridViewInvoke_Callback _invoke = new SetDataGridViewInvoke_Callback(Set_Invoke_DataGridView);
                _control.Invoke(_invoke, new object[] { _control, _values });
            }
            else
            {
                _control.Rows.Clear();
                foreach (var row in _values)
                {
                    _control.Rows.Add(row);
                }
            }
        }
    }
}
