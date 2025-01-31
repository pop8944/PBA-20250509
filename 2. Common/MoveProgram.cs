using System.Drawing;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class MoveProgram
    {
        #region 전역변수
        bool isMove = false;
        Point fPt = new Point(0, 0);
        Form mfrm_Move;
        #endregion

        #region 생성자
        public MoveProgram(Form frm_Move)
        {
            mfrm_Move = frm_Move;

            mfrm_Move.MouseDown += new MouseEventHandler(Ctl_MouseDown);
            mfrm_Move.MouseUp += new MouseEventHandler(Ctl_MouseUp);
            mfrm_Move.MouseMove += new MouseEventHandler(Ctl_MouseMove);
        }
        #endregion

        #region 위치 이동
        public void Move(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.MouseDown += new MouseEventHandler(Ctl_MouseDown);
                control.MouseUp += new MouseEventHandler(Ctl_MouseUp);
                control.MouseMove += new MouseEventHandler(Ctl_MouseMove);
            }
        }

        public void Ctl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = true;
                fPt = new Point(e.X, e.Y);
            }
        }

        public void Ctl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove && (e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                mfrm_Move.Location = new Point(mfrm_Move.Left - (fPt.X - e.X), mfrm_Move.Top - (fPt.Y - e.Y));
            }
        }

        public void Ctl_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        #endregion
    }
}
