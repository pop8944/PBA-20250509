using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IntelligentFactory
{
    class RichTextBoxEx : RichTextBox
    {
        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        public RichTextBoxEx()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            BorderStyle = BorderStyle.FixedSingle;
        }

        protected override void WndProc(ref Message m)
        {
            //WM_LBUTTONDOWN
            if (m.Msg == 0x201)
                HideCaret(m.HWnd);
            else
                base.WndProc(ref m);
        }
    }
}