using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormMenu_Measure : Form
    {
        private Global Global = Global.Instance;

        private Bitmap _imgSource;
        private Bitmap _imgDisplay;

        private List<PointF> _points = new List<PointF>();
        private double _PixelSize_mm = 0.01D;

        private const double Magnification = 4;

        public FormMenu_Measure(Bitmap img)
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(MouseWheelEvent);

            _imgSource = (Bitmap)img.Clone();
            _imgDisplay = new Bitmap(img, new System.Drawing.Size((int)(img.Width / Magnification), (int)(img.Height / Magnification)));

            ibSource.Image = (Bitmap)_imgDisplay.Clone();
        }

        private void FormMenu_Measure_Load(object sender, EventArgs e)
        {
            try
            {
                CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if ((e.Delta / 120) > 0) ibSource.ZoomIn();
            else ibSource.ZoomOut();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ibSource_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ibSource.ZoomToFit();
        }

        private void ibSource_MouseDown(object sender, MouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Button == MouseButtons.Left) _points.Add(ibSource.PointToImage(e.Location));
            }
        }

        private PointF ptMouse = new System.Drawing.Point();

        private void ibSource_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                ptMouse = ibSource.PointToImage(e.Location);
                if (_points.Count > 0)
                {
                    using (Bitmap imgDisplay = (Bitmap)_imgDisplay.Clone())
                    using (Graphics g = Graphics.FromImage(imgDisplay))
                    {
                        PointF ptMouse = ibSource.PointToImage(e.Location);
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        if (_points.Count == 1)
                        {
                            DrawPoint(g, _points[0], Brushes.Yellow, Pens.Green);

                            using (Pen dashed_pen = new Pen(Color.Green))
                            {
                                dashed_pen.DashStyle = DashStyle.Custom;
                                dashed_pen.DashPattern = new float[] { 4, 4 };
                                g.DrawLine(dashed_pen, _points[0], ptMouse);
                            }
                        }

                        if (_points.Count == 2)
                        {
                            DrawPoint(g, _points[0], Brushes.Yellow, Pens.Green);
                            DrawPoint(g, _points[1], Brushes.Yellow, Pens.Green);
                            g.DrawLine(Pens.Green, _points[0], _points[1]);

                            FindDistanceToSegment(ptMouse, _points[0], _points[1], out PointF closet);

                            using (Pen dashed_pen = new Pen(Color.Red))
                            {
                                dashed_pen.DashStyle = DashStyle.Custom;
                                dashed_pen.DashPattern = new float[] { 4, 4 };
                                g.DrawLine(dashed_pen, closet, ptMouse);
                            }
                            DrawPoint(g, closet, Brushes.HotPink, Pens.Red);
                            DrawPoint(g, ptMouse, Brushes.HotPink, Pens.Red);

                            double dDist = Math.Sqrt(Math.Pow((ptMouse.X - closet.X), 2) + Math.Pow((ptMouse.Y - closet.Y), 2)) * _PixelSize_mm;
                            g.DrawString($"{dDist.ToString("F3")}mm", new Font("Arial", 10, FontStyle.Bold), Brushes.Green, ptMouse);
                        }

                        if (_points.Count == 3)
                        {
                            DrawPoint(g, _points[0], Brushes.Yellow, Pens.Green);
                            DrawPoint(g, _points[1], Brushes.Yellow, Pens.Green);
                            g.DrawLine(Pens.Green, _points[0], _points[1]);

                            FindDistanceToSegment(_points[2], _points[0], _points[1], out PointF closet);

                            using (Pen dashed_pen = new Pen(Color.Red))
                            {
                                dashed_pen.DashStyle = DashStyle.Custom;
                                dashed_pen.DashPattern = new float[] { 4, 4 };
                                g.DrawLine(dashed_pen, closet, _points[2]);
                            }
                            DrawPoint(g, closet, Brushes.HotPink, Pens.Red);
                            DrawPoint(g, _points[2], Brushes.HotPink, Pens.Red);

                            double dDist = Math.Sqrt(Math.Pow((_points[2].X - closet.X), 2) + Math.Pow((_points[2].Y - closet.Y), 2)) * _PixelSize_mm;
                            g.DrawString($"{dDist.ToString("F3")}mm", new Font("Arial", 10, FontStyle.Bold), Brushes.Green, _points[2]);

                            _points.Clear();
                        }

                        ibSource.Image.Dispose();
                        ibSource.Image = null;

                        ibSource.Image = (Bitmap)imgDisplay.Clone();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private double FindDistanceToSegment(
            PointF pt, PointF p1, PointF p2, out PointF closest)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new PointF(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void DrawPoint(Graphics gr, PointF pt, Brush brush, Pen pen)
        {
            const int RADIUS = 4;
            gr.FillEllipse(brush,
                pt.X - RADIUS, pt.Y - RADIUS,
                2 * RADIUS, 2 * RADIUS);
            gr.DrawEllipse(pen,
                pt.X - RADIUS, pt.Y - RADIUS,
                2 * RADIUS, 2 * RADIUS);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_points.Count > 0)
                {
                    using (Bitmap imgDisplay = (Bitmap)_imgDisplay.Clone())
                    using (Graphics g = Graphics.FromImage(imgDisplay))
                    {
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        if (_points.Count == 1)
                        {
                            DrawPoint(g, _points[0], Brushes.Yellow, Pens.Green);

                            using (Pen dashed_pen = new Pen(Color.Green))
                            {
                                dashed_pen.DashStyle = DashStyle.Custom;
                                dashed_pen.DashPattern = new float[] { 4, 4 };
                                g.DrawLine(dashed_pen, _points[0], ptMouse);
                            }
                        }

                        if (_points.Count == 2)
                        {
                            DrawPoint(g, _points[0], Brushes.Yellow, Pens.Green);
                            DrawPoint(g, _points[1], Brushes.Yellow, Pens.Green);
                            g.DrawLine(Pens.Green, _points[0], _points[1]);

                            FindDistanceToSegment(ptMouse, _points[0], _points[1], out PointF closet);

                            using (Pen dashed_pen = new Pen(Color.Red))
                            {
                                dashed_pen.DashStyle = DashStyle.Custom;
                                dashed_pen.DashPattern = new float[] { 4, 4 };
                                g.DrawLine(dashed_pen, closet, ptMouse);
                            }
                            DrawPoint(g, closet, Brushes.HotPink, Pens.Red);
                            DrawPoint(g, ptMouse, Brushes.HotPink, Pens.Red);

                            double dDist = Math.Sqrt(Math.Pow((ptMouse.X - closet.X), 2) + Math.Pow((ptMouse.Y - closet.Y), 2)) * _PixelSize_mm * Magnification;
                            g.DrawString($"{dDist.ToString("F3")}mm", new Font("Arial", 10, FontStyle.Bold), Brushes.Green, ptMouse);
                        }

                        if (_points.Count == 3)
                        {
                            DrawPoint(g, _points[0], Brushes.Yellow, Pens.Green);
                            DrawPoint(g, _points[1], Brushes.Yellow, Pens.Green);
                            g.DrawLine(Pens.Green, _points[0], _points[1]);

                            FindDistanceToSegment(_points[2], _points[0], _points[1], out PointF closet);

                            using (Pen dashed_pen = new Pen(Color.Red))
                            {
                                dashed_pen.DashStyle = DashStyle.Custom;
                                dashed_pen.DashPattern = new float[] { 4, 4 };
                                g.DrawLine(dashed_pen, closet, _points[2]);
                            }
                            DrawPoint(g, closet, Brushes.HotPink, Pens.Red);
                            DrawPoint(g, _points[2], Brushes.HotPink, Pens.Red);

                            double dDist = Math.Sqrt(Math.Pow((_points[2].X - closet.X), 2) + Math.Pow((_points[2].Y - closet.Y), 2)) * _PixelSize_mm * Magnification;
                            g.DrawString($"{dDist.ToString("F3")}mm", new Font("Arial", 10, FontStyle.Bold), Brushes.Green, _points[2]);

                            _points.Clear();
                        }

                        ibSource.Image.Dispose();
                        ibSource.Image = null;

                        ibSource.Image = (Bitmap)imgDisplay.Clone();
                    }
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                double.TryParse(tbPixelSize.Text, out _PixelSize_mm);
            }
            catch
            {
            }
        }
    }
}