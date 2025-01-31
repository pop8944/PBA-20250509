using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace IntelligentFactory
{
    public class CIndexData
    {
        public PointF pos = new PointF();
        public int nIndex = 0;

        public CIndexData()
        {
        }

        public CIndexData(int nindex, float fX, float fY)
        {
            pos = new PointF(fX, fY);
            nIndex = nindex;
        }
    }

    public partial class IntelligentGraph : Control
    {
        private string m_strDesc = "EMPTY";

        public string Desc
        {
            get { return m_strDesc; }
            set { m_strDesc = value; }
        }

        private string m_strUnit = "mVDC";

        public string Unit
        {
            get { return m_strUnit; }
            set { m_strUnit = value; }
        }

        private int m_nIndex = 0;

        public int Index
        {
            get { return m_nIndex; }
            set { m_nIndex = value; }
        }

        public class LineHandle
        {
            private Line m_Line = null;
            private IntelligentGraph m_Owner = null;

            // ===================================================================

            public LineHandle(ref Object line, IntelligentGraph owner)
            {
                /* A small hack to get around the compiler error CS0051: */
                if (string.Compare(line.GetType().Name, "Line") != 0)
                {
                    throw new System.ArithmeticException(
                        "LineHandle: First Parameter must be " +
                        "type of 'Line' cast to base 'Object'");
                }

                m_Line = (Line)line;
                m_Owner = owner;
            }

            // ===================================================================

            /// <summary>
            /// Clears any currently displayed magnitudes.
            /// </summary>

            public Color Color
            {
                set
                {
                    if (m_Line.m_Color != value)
                    {
                        m_Line.m_Color = value;
                        m_Owner.Refresh();
                    }
                }
                get { return m_Line.m_Color; }
            }

            public uint Thickness
            {
                set
                {
                    if (m_Line.m_Thickness != value)
                    {
                        m_Line.m_Thickness = value;
                        m_Owner.Refresh();
                    }
                }
                get { return m_Line.m_Thickness; }
            }

            public bool Visible
            {
                set
                {
                    if (m_Line.m_bVisible != value)
                    {
                        m_Line.m_bVisible = value;
                        m_Owner.Refresh();
                    }
                }
                get { return m_Line.m_bVisible; }
            }

            public bool ShowAsBar
            {
                set
                {
                    if (m_Line.m_bShowAsBar != value)
                    {
                        m_Line.m_bShowAsBar = value;
                        m_Owner.Refresh();
                    }
                }
                get { return m_Line.m_bShowAsBar; }
            }
        }

        private class Line
        {
            public List<int> m_HighLimitList = new List<int>();
            public List<int> m_LowLimitList = new List<int>();
            public List<double> m_MagnitudeList = new List<double>();
            public Color m_Color = Color.Green;
            public string m_NameID = "IR";
            public int m_NumID = -1;
            public uint m_Thickness = 1;
            public bool m_bShowAsBar = false;
            public bool m_bVisible = true;

            public double m_dMax = double.MinValue;
            public double m_dMin = double.MaxValue;

            public Line(string name)
            {
                m_NameID = name;
            }

            public Line(int num)
            {
                m_NumID = num;
            }
        }

        private PowerGraphConfig m_PowerGraphConfig = new PowerGraphConfig();

        public PowerGraphConfig PowerGraphConfig
        {
            get { return m_PowerGraphConfig; }
            set { m_PowerGraphConfig = value; }
        }

        private Color m_TextColor = Color.Aquamarine;
        private Color m_GridColor = Color.DimGray;
        private string m_MaxLabel = "Max";
        private string m_MidLabel = "Mid";
        private string m_MinLabel = "Minimum";
        private bool m_bHighQuality = true;
        private bool m_bAutoScale = false;
        //private bool m_bMinLabelSet = false;
        //private bool m_bMidLabelSet = false;
        //private bool m_bMaxLabelSet = false;
        private bool m_bShowMinMax = true;
        //private bool m_bShowCurrentData = true;
        private bool m_bShowGrid = true;
        //private int m_MoveOffset = 0;
        //private int m_MaxCoords = -1;
        private int m_LineInterval = 5;
        //private double m_MaxPeek = 100;
        //private double m_MinPeek = 0;
        private int m_GridSize = 15;
        //private int m_OffsetX = 0;

        private List<Line> m_Lines = new List<Line>();

        public int m_CurrPos = 0;

        public IntelligentGraph()
        {
            InitializeComponent();
            InitializeStyles();

            UpdateStyles(m_PowerGraphConfig);
        }

        public IntelligentGraph(int nIndex, string strDesc)
        {
            InitializeComponent();
            InitializeStyles();

            m_nIndex = nIndex;
            m_strDesc = strDesc;

            UpdateStyles(m_PowerGraphConfig);
        }

        public IntelligentGraph(Form Parent)
        {
            Parent.Controls.Add(this);

            InitializeComponent();
            InitializeStyles();
        }

        public IntelligentGraph(Form parent, Rectangle rectPos)
        {
            parent.Controls.Add(this);

            Location = rectPos.Location;
            Height = rectPos.Height;
            Width = rectPos.Width;

            InitializeComponent();
            InitializeStyles();
        }

        private void InitializeStyles()
        {
            BackColor = Color.Black;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            DoubleBuffered = true;

            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public void UpdateStyles(PowerGraphConfig config)
        {
            m_PowerGraphConfig.TextColor = config.TextColor;
            m_PowerGraphConfig.CurrentDataColor = config.CurrentDataColor;
            m_PowerGraphConfig.BackgroundColor = config.BackgroundColor;
            m_PowerGraphConfig.GridColor = config.GridColor;
            m_PowerGraphConfig.SpecInColor = config.SpecInColor;
            m_PowerGraphConfig.SpecOutColor = config.SpecOutColor;
            m_PowerGraphConfig.WarningLineColor = config.WarningLineColor;
            m_PowerGraphConfig.AlarmLineColor = config.AlarmLineColor;
            m_PowerGraphConfig.BorderLineColor = config.BorderLineColor;

            m_PowerGraphConfig.IsViewModeLine = config.IsViewModeLine;
            m_PowerGraphConfig.IsReverse = config.IsReverse;

            m_PowerGraphConfig.GapX = config.GapX;
            m_PowerGraphConfig.GapY = config.GapY;

            m_PowerGraphConfig.FontSize = config.FontSize;
            m_PowerGraphConfig.LeftFontSize = config.LeftFontSize;
            m_PowerGraphConfig.PointSize = config.PointSize;

            m_PowerGraphConfig.Max = config.Max;
            m_PowerGraphConfig.Min = config.Min;

            m_PowerGraphConfig.ListMaxCount = config.ListMaxCount;

            m_PowerGraphConfig.IsLimitPeak = config.IsLimitPeak;

            this.MaxValueY = m_PowerGraphConfig.Max;
            this.MinValueY = m_PowerGraphConfig.Min;

            this.MaxLabel = m_PowerGraphConfig.Max.ToString();
            this.MinLabel = m_PowerGraphConfig.Min.ToString();

            LineInterval = (ushort)config.GapX;
            this.BackColor = m_PowerGraphConfig.BackgroundColor;

            this.Refresh();
        }

        public Color TextColor
        {
            set
            {
                if (m_TextColor != value)
                {
                    m_TextColor = value;
                    Refresh();
                }
            }
            get { return m_TextColor; }
        }

        public Color GridColor
        {
            set
            {
                if (m_GridColor != value)
                {
                    m_GridColor = value;
                    Refresh();
                }
            }
            get { return m_GridColor; }
        }

        public ushort LineInterval
        {
            set
            {
                if ((ushort)m_LineInterval != value)
                {
                    m_LineInterval = (int)value;
                    //m_MaxCoords = -1; // Recalculate
                    Refresh();
                }
            }
            get { return (ushort)m_LineInterval; }
        }

        public string MaxLabel
        {
            set
            {
                //m_bMaxLabelSet = true;

                if (string.Compare(m_MaxLabel, value) != 0)
                {
                    m_MaxLabel = value;
                    //m_MaxCoords = -1;
                    Refresh();
                }
            }
            get { return m_MaxLabel; }
        }

        public string MidLabel
        {
            set
            {
                //m_bMidLabelSet = true;

                if (string.Compare(m_MidLabel, value) != 0)
                {
                    m_MidLabel = value;
                    Refresh();
                }
            }
            get { return m_MidLabel; }
        }

        public string MinLabel
        {
            set
            {
                //m_bMinLabelSet = true;

                if (string.Compare(m_MinLabel, value) != 0)
                {
                    m_MinLabel = value;
                    //m_MaxCoords = -1;
                    Refresh();
                }
            }
            get { return m_MinLabel; }
        }

        public ushort GridSize
        {
            set
            {
                if (m_GridSize != (int)value)
                {
                    m_GridSize = (int)value;
                    Refresh();
                }
            }
            get { return (ushort)m_GridSize; }
        }

        public bool AutoAdjustPeek
        {
            set
            {
                if (m_bAutoScale != value)
                {
                    m_bAutoScale = value;
                    Refresh();
                }
            }
            get { return m_bAutoScale; }
        }

        public bool HighQuality
        {
            set
            {
                if (value != m_bHighQuality)
                {
                    m_bHighQuality = value;
                    Refresh(); // Force redraw
                }
            }
            get { return m_bHighQuality; }
        }

        public bool ShowLabels
        {
            set
            {
                if (m_bShowMinMax != value)
                {
                    m_bShowMinMax = value;

                    //m_MaxCoords = -1;

                    Refresh();
                }
            }
            get { return m_bShowMinMax; }
        }

        public bool ShowGrid
        {
            set
            {
                if (m_bShowGrid != value)
                {
                    m_bShowGrid = value;
                    Refresh();
                }
            }
            get { return m_bShowGrid; }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            //m_MaxCoords = -1;

            Refresh();

            base.OnSizeChanged(e);
        }

        private float m_fZoomScale = 1.0F;

        public float ZoomScale
        {
            get { return m_fZoomScale; }
            set
            {
                float fZooomScale = value;
                if (fZooomScale < 1)
                {
                    m_fZoomScale = 1.0F;
                }
                else
                {
                    float fZoomGap = ((MaxValueY - MinValueY) * (fZooomScale - 1.0F)) / 2.0F;

                    float fMid = (MaxValueY - MinValueY) / 2.0F;
                    if (fMid - fZoomGap > 1)
                    {
                        m_fZoomScale = value;
                    }
                }
            }
        }

        private int m_nDulplexPointCount = 1;

        public int DulplexPointCount
        {
            get
            {
                return m_nDulplexPointCount;
            }

            set
            {
                int nDulplexPointCount = value;
                if (nDulplexPointCount <= 0)
                {
                    nDulplexPointCount = 1;
                }

                m_nDulplexPointCount = nDulplexPointCount;
            }
        }

        public float MinValueX;
        public float MaxValueX;

        public float Spec_Alarm_Min = -3.5F;
        public float Spec_Alarm_Max = 3.5F;
        public float Spec_Warning_Min = -2.5F;
        public float Spec_Warning_Max = 2.5F;

        public float MaxValueY
        {
            get;
            set;
        }

        public float MinValueY
        {
            get;
            set;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float fStartX = 40;
            float fStartY = 10;
            float fEndX = Width - 5;
            float fEndY = Height - 40;

            Graphics g = e.Graphics;// CreateGraphics();

            SmoothingMode prevSmoothingMode = g.SmoothingMode;
            g.SmoothingMode = (m_bHighQuality ? SmoothingMode.HighQuality
                                                : SmoothingMode.Default);

            g.FillRectangle(new SolidBrush(Color.FromArgb(34, 39, 59)), new Rectangle(0, 0, Width, Height));
            g.FillRectangle(new SolidBrush(Color.FromArgb(58, 63, 82)), new Rectangle(40, 10, Width - 45, Height - 40));

            Pen penDashLine_Red = new Pen(Color.Red, 1);
            Pen penDashLine_Green = new Pen(Color.Green, 1);
            Pen penDashLine_White = new Pen(Color.White, 1);

            penDashLine_Red.DashStyle = DashStyle.DashDot;
            penDashLine_Green.DashStyle = DashStyle.DashDot;
            penDashLine_White.DashStyle = DashStyle.DashDot;

            //g.DrawLine(penDashLine_Red, 75, Height / 2 - (Height / 3) + 5, Width - 10, Height / 2 - (Height / 3) + 5);
            //g.DrawLine(penDashLine_Green, 75, Height / 2 + 5, Width - 10, Height / 2 + 5);
            //g.DrawLine(penDashLine_Red, 75, Height / 2 + (Height / 3) + 5, Width - 10, Height / 2 + (Height / 3) + 5);

            SizeF maxSize = g.MeasureString(m_MaxLabel, Font);
            SizeF minSize = g.MeasureString(m_MinLabel, Font);

            Font font = new Font("Arial", 9);
            SolidBrush brushWhite = new SolidBrush(Color.White);

            //g.FillEllipse(new SolidBrush(Color.Red), 48, Height / 2 - (Height / 3), 10, 10);
            //g.FillEllipse(new SolidBrush(Color.Green), 48, Height / 2, 10, 10);
            //g.FillEllipse(new SolidBrush(Color.Red), 48, Height / 2 + (Height / 3), 10, 10);

            float fX_Center = fStartX + (fEndX - fStartX) / 2;
            float fY_Center = fStartY + (fEndY - fStartY) / 2;

            g.DrawLine(penDashLine_White, fStartX, fY_Center, fEndX, fY_Center);
            g.DrawLine(penDashLine_White, fX_Center, fStartY, fX_Center, fEndY);

            g.DrawString($"{MaxValueY}", font, brushWhite, new PointF(5, fStartY));
            g.DrawString($"{MinValueY + (MaxValueY - MinValueY) / 2}", font, brushWhite, new PointF(5, fStartY + (fEndY - fStartY) / 2));
            g.DrawString($"{MinValueY}", font, brushWhite, new PointF(5, fEndY));

            g.DrawString($"{MinValueX}", font, brushWhite, new PointF(fStartX, Height - 30));
            g.DrawString($"{MinValueX + (MaxValueX - MinValueX) / 2}", font, brushWhite, new PointF(fStartX + (fEndX - fStartX) / 2, Height - 30));
            g.DrawString($"{MaxValueX}", font, brushWhite, new PointF(fStartX + (fEndX - fStartX) - 5, Height - 30));

            float fIntervalX = Math.Abs(MinValueX - MaxValueX);
            float fIntervalY = Math.Abs(MinValueY - MaxValueY);

            for (int i = 0; i < data.Count; i++)
            {
                float fX = fStartX + (fEndX - fStartX) * (data[i].pos.X / fIntervalX) + (fEndX - fStartX) / 2;
                float fY = fEndY - (fEndY - fStartY) * (data[i].pos.Y / fIntervalY) - (fEndY - fStartY) / 2;

                Color ShuttleColor = new Color();
                if (data[i].nIndex == 0) ShuttleColor = Color.Yellow;
                if (data[i].nIndex == 1) ShuttleColor = Color.LightBlue;
                if (data[i].nIndex == 2) ShuttleColor = Color.LightGreen;
                if (data[i].nIndex == 3) ShuttleColor = Color.IndianRed;

                if (i == (int)(data.Count - 1))
                {
                    g.FillEllipse(new SolidBrush(Color.Orange), fX - 5, fY - 5, 5, 5);
                    g.DrawString($"X : {data[i].pos.X}mm", new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Orange), fX + 5, fY);
                    g.DrawString($"Y : {data[i].pos.Y}mm", new Font("Arial", 12, FontStyle.Bold), new SolidBrush(Color.Orange), fX + 5, fY + 20);
                }
                else
                {
                    g.FillEllipse(new SolidBrush(ShuttleColor), fX - 5, fY - 5, 5, 5);
                }
            }

            //가이드 라인 (알람)
            {
                float fX = fStartX + (fEndX - fStartX) * (Spec_Alarm_Min / fIntervalX) + (fEndX - fStartX) / 2;
                float fY = fEndY - (fEndY - fStartY) * (Spec_Alarm_Max / fIntervalY) - (fEndY - fStartY) / 2;

                float fW = (fStartX + (fEndX - fStartX) * (Spec_Alarm_Max / fIntervalX) + (fEndX - fStartX) / 2) - fX;
                float fH = (fEndY - (fEndY - fStartY) * (Spec_Alarm_Min / fIntervalY) - (fEndY - fStartY) / 2) - fY;

                g.DrawRectangle(penDashLine_Red, fX, fY, fW, fH);

                g.DrawString($"{Spec_Alarm_Min}", font, brushWhite, new PointF(fX, Height - 30));
                g.DrawString($"{Spec_Alarm_Max}", font, brushWhite, new PointF(fX + fW, Height - 30));

                g.DrawString($"{Spec_Alarm_Max}", font, brushWhite, new PointF(5, fY));
                g.DrawString($"{Spec_Alarm_Min}", font, brushWhite, new PointF(5, fY + fH));

                g.DrawString($"{Spec_Alarm_Min}", font, brushWhite, new PointF(fStartX, Height - 30));
            }

            //가이드 라인 (워닝)
            {
                float fX = fStartX + (fEndX - fStartX) * (Spec_Warning_Min / fIntervalX) + (fEndX - fStartX) / 2;
                float fY = fEndY - (fEndY - fStartY) * (Spec_Warning_Max / fIntervalY) - (fEndY - fStartY) / 2;

                float fW = (fStartX + (fEndX - fStartX) * (Spec_Warning_Max / fIntervalX) + (fEndX - fStartX) / 2) - fX;
                float fH = (fEndY - (fEndY - fStartY) * (Spec_Warning_Min / fIntervalY) - (fEndY - fStartY) / 2) - fY;

                g.DrawRectangle(penDashLine_Green, fX, fY, fW, fH);

                g.DrawString($"{Spec_Warning_Min}", font, brushWhite, new PointF(fX, Height - 30));
                g.DrawString($"{Spec_Warning_Max}", font, brushWhite, new PointF(fX + fW, Height - 30));

                g.DrawString($"{Spec_Warning_Max}", font, brushWhite, new PointF(5, fY));
                g.DrawString($"{Spec_Warning_Min}", font, brushWhite, new PointF(5, fY + fH));
            }

            brushWhite.Dispose();
            penDashLine_Red.Dispose();
            penDashLine_Green.Dispose();
            g.SmoothingMode = prevSmoothingMode;
        }

        public int OffsetY = 0;

        public List<CIndexData> data = new List<CIndexData>();
        public List<PointF> points = new List<PointF>();

        public void AddPoint(int nIndex, float fX, float fY)
        {
            data.Add(new CIndexData(nIndex, fX, fY));
            this.Refresh();
        }

        public void AddPoint(float fX, float fY)
        {
            points.Add(new PointF(fX, fY));
            this.Refresh();
        }

        #region File Manager

        private string m_XMLName = "Graph";

        public bool ReadInitFile()
        {
            try
            {
                string strPath = Global.m_MainPJTRoot + "\\" + m_XMLName + Index.ToString() + ".xml";

                if (File.Exists(strPath))
                {
                    XmlTextReader xmlReader = new XmlTextReader(strPath);

                    try
                    {
                        ReadInitFileFromXML(xmlReader);
                    }
                    catch (Exception ex)
                    {
                        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                        xmlReader.Close();
                    }

                    xmlReader.Close();
                }
                else
                {
                    WriteInitFile();
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }

        public bool WriteInitFile()
        {
            string strPath = Global.m_MainPJTRoot + "\\" + m_XMLName + Index.ToString() + ".xml";

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();

                WriteInitFileToXML(xmlWriter);
                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }

            CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public bool ReadInitFileFromXML(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (xmlReader.Name)
                    {
                        case "MinValue":
                            if (!xmlReader.Read()) return false;
                            MinValueY = float.Parse(xmlReader.Value);
                            break;

                        case "MaxValue":
                            if (!xmlReader.Read()) return false;
                            MaxValueY = float.Parse(xmlReader.Value);
                            break;

                        case "Desc":
                            if (!xmlReader.Read()) return false;
                            Desc = xmlReader.Value;
                            break;

                        case "Unit":
                            if (!xmlReader.Read()) return false;
                            Unit = xmlReader.Value;
                            break;
                    }
                }
                else
                {
                    if (xmlReader.NodeType == XmlNodeType.EndElement)
                    {
                        if (xmlReader.Name == m_XMLName) break;
                    }
                }
            }

            CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public bool WriteInitFileToXML(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("MainConfig");
            xmlWriter.WriteElementString("MinValue", MinValueY.ToString("F2"));
            xmlWriter.WriteElementString("MaxValue", MaxValueY.ToString("F2"));
            xmlWriter.WriteElementString("Desc", Desc);
            xmlWriter.WriteElementString("Unit", Unit);
            xmlWriter.WriteEndElement();
            return true;
        }

        #endregion File Manager
    }

    public class PowerGraphConfig
    {
        private int m_nSpecOutPeakCount = 0;

        public int SpecOutPeakCount
        {
            get
            {
                return m_nSpecOutPeakCount;
            }
            set
            {
                m_nSpecOutPeakCount = value;
            }
        }

        private int m_nSpecOutAverCount = 0;

        public int SpecOutAverCount
        {
            get
            {
                return m_nSpecOutAverCount;
            }
            set
            {
                m_nSpecOutAverCount = value;
            }
        }

        private Color m_TextColor = Color.Aquamarine;

        public Color TextColor
        {
            get
            {
                return m_TextColor;
            }
            set
            {
                m_TextColor = value;
            }
        }

        private Color m_CurrentDataColor = Color.Blue;

        public Color CurrentDataColor
        {
            get
            {
                return m_CurrentDataColor;
            }
            set
            {
                m_CurrentDataColor = value;
            }
        }

        private Color m_BackgroundColor = Color.Black;

        public Color BackgroundColor
        {
            get
            {
                return m_BackgroundColor;
            }
            set
            {
                m_BackgroundColor = value;
            }
        }

        private Color m_GridColor = Color.Black;

        public Color GridColor
        {
            get
            {
                return m_GridColor;
            }
            set
            {
                m_GridColor = value;
            }
        }

        private Color m_SpecInColor = Color.Blue;

        public Color SpecInColor
        {
            get
            {
                return m_SpecInColor;
            }
            set
            {
                m_SpecInColor = value;
            }
        }

        private Color m_SpecOutColor = Color.Red;

        public Color SpecOutColor
        {
            get
            {
                return m_SpecOutColor;
            }
            set
            {
                m_SpecOutColor = value;
            }
        }

        private Color m_WarningLineColor = Color.LightPink;

        public Color WarningLineColor
        {
            get
            {
                return m_WarningLineColor;
            }
            set
            {
                m_WarningLineColor = value;
            }
        }

        private Color m_AlarmLineColor = Color.Red;

        public Color AlarmLineColor
        {
            get
            {
                return m_AlarmLineColor;
            }
            set
            {
                m_AlarmLineColor = value;
            }
        }

        private Color m_BorderLineColor = Color.White;

        public Color BorderLineColor
        {
            get
            {
                return m_BorderLineColor;
            }
            set
            {
                m_BorderLineColor = value;
            }
        }

        private int m_nPointSize = 5;

        public int PointSize
        {
            get
            {
                return m_nPointSize;
            }
            set
            {
                m_nPointSize = value;
            }
        }

        private int m_nGapX = 1;

        public int GapX
        {
            get
            {
                return m_nGapX;
            }
            set
            {
                m_nGapX = value;
            }
        }

        private int m_nGapY = 1;

        public int GapY
        {
            get
            {
                return m_nGapY;
            }
            set
            {
                m_nGapY = value;
            }
        }

        private int m_nMax = 1000;

        public int Max
        {
            get
            {
                return m_nMax;
            }
            set
            {
                m_nMax = value;
            }
        }

        private int m_nMin = 0;

        public int Min
        {
            get
            {
                return m_nMin;
            }
            set
            {
                m_nMin = value;
            }
        }

        private bool m_bIsViewModeLine = true;

        public bool IsViewModeLine
        {
            get
            {
                return m_bIsViewModeLine;
            }
            set
            {
                m_bIsViewModeLine = value;
            }
        }

        private bool m_bIsLimitPeak = true;

        public bool IsLimitPeak
        {
            get
            {
                return m_bIsLimitPeak;
            }
            set
            {
                m_bIsLimitPeak = value;
            }
        }

        private int m_nFontSize = 12;

        public int FontSize
        {
            get
            {
                return m_nFontSize;
            }
            set
            {
                m_nFontSize = value;
            }
        }

        private int m_nLeftFontSize = 10;

        public int LeftFontSize
        {
            get
            {
                return m_nLeftFontSize;
            }
            set
            {
                m_nLeftFontSize = value;
            }
        }

        private int m_nListMaxCount = 20000;

        public int ListMaxCount
        {
            get
            {
                return m_nListMaxCount;
            }
            set
            {
                m_nListMaxCount = value;
            }
        }

        private bool m_bReverse = false;

        public bool IsReverse
        {
            get
            {
                return m_bReverse;
            }
            set
            {
                m_bReverse = value;
            }
        }

        public PowerGraphConfig()
        {
        }

        private string m_strPath = Global.m_MainPJTRoot + "PowerGraphConfig.cfg";
        private string m_XMLName = "PowerGraphConfig";

        public bool ReadInitFile()
        {
            try
            {
                if (File.Exists(m_strPath))   //  xml 파일 존재 유무 검사
                {
                    XmlTextReader xmlReader = new XmlTextReader(m_strPath);    //  xml 파일 열기

                    try
                    {
                        ReadInitFileFromXML(xmlReader);
                    }
                    catch (Exception ex)
                    {
                        CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                        xmlReader.Close();
                    }

                    xmlReader.Close();
                }
                else
                {
                    CLogger.Add(LOG.ABNORMAL, "File is't exist => " + m_strPath);
                    return false;
                }
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
                return false;
            }
            return true;
        }

        public bool WriteInitFile()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            XmlWriter xmlWriter = XmlWriter.Create(m_strPath, settings);
            try
            {
                xmlWriter.WriteStartDocument();

                WriteInitFileToXML(xmlWriter);
                xmlWriter.WriteEndDocument();
            }
            catch (Exception ex)
            {
                CLogger.Exception(MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex);
            }
            finally
            {
                xmlWriter.Flush();
                xmlWriter.Close();
            }
            return true;
        }

        public bool ReadInitFileFromXML(XmlReader xmlReader)
        {
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    switch (xmlReader.Name)
                    {
                        case "TextColor":
                            if (!xmlReader.Read()) return false;
                            string[] strColor = xmlReader.Value.Split(',');
                            if (strColor.Length == 3)
                                TextColor = Color.FromArgb(int.Parse(strColor[0]), int.Parse(strColor[1]), int.Parse(strColor[2]));
                            break;

                        case "CurrentDataColor":
                            if (!xmlReader.Read()) return false;
                            strColor = xmlReader.Value.Split(',');
                            if (strColor.Length == 3)
                                CurrentDataColor = Color.FromArgb(int.Parse(strColor[0]), int.Parse(strColor[1]), int.Parse(strColor[2]));
                            break;

                        case "BackgroundColor":
                            if (!xmlReader.Read()) return false;
                            strColor = xmlReader.Value.Split(',');
                            if (strColor.Length == 3)
                                BackgroundColor = Color.FromArgb(int.Parse(strColor[0]), int.Parse(strColor[1]), int.Parse(strColor[2]));
                            break;

                        case "GridColor":
                            if (!xmlReader.Read()) return false;
                            strColor = xmlReader.Value.Split(',');
                            if (strColor.Length == 3)
                                GridColor = Color.FromArgb(int.Parse(strColor[0]), int.Parse(strColor[1]), int.Parse(strColor[2]));
                            break;

                        case "SpecInColor":
                            if (!xmlReader.Read()) return false;
                            strColor = xmlReader.Value.Split(',');
                            if (strColor.Length == 3)
                                SpecInColor = Color.FromArgb(int.Parse(strColor[0]), int.Parse(strColor[1]), int.Parse(strColor[2]));
                            break;

                        case "SpecOutColor":
                            if (!xmlReader.Read()) return false;
                            strColor = xmlReader.Value.Split(',');
                            if (strColor.Length == 3)
                                SpecOutColor = Color.FromArgb(int.Parse(strColor[0]), int.Parse(strColor[1]), int.Parse(strColor[2]));
                            break;

                        case "WarningLineColor":
                            if (!xmlReader.Read()) return false;
                            strColor = xmlReader.Value.Split(',');
                            if (strColor.Length == 3)
                                WarningLineColor = Color.FromArgb(int.Parse(strColor[0]), int.Parse(strColor[1]), int.Parse(strColor[2]));
                            break;

                        case "AlarmLineColor":
                            if (!xmlReader.Read()) return false;
                            strColor = xmlReader.Value.Split(',');
                            if (strColor.Length == 3)
                                AlarmLineColor = Color.FromArgb(int.Parse(strColor[0]), int.Parse(strColor[1]), int.Parse(strColor[2]));
                            break;

                        case "PointSize":
                            if (!xmlReader.Read()) return false;
                            PointSize = int.Parse(xmlReader.Value);
                            break;

                        case "GapX":
                            if (!xmlReader.Read()) return false;
                            GapX = int.Parse(xmlReader.Value);
                            break;

                        case "GapY":
                            if (!xmlReader.Read()) return false;
                            GapY = int.Parse(xmlReader.Value);
                            break;

                        case "IsViewModeLine":
                            if (!xmlReader.Read()) return false;
                            IsViewModeLine = bool.Parse(xmlReader.Value);
                            break;

                        case "IsLimitPeak":
                            if (!xmlReader.Read()) return false;
                            IsLimitPeak = bool.Parse(xmlReader.Value);
                            break;

                        case "FontSize":
                            if (!xmlReader.Read()) return false;
                            FontSize = int.Parse(xmlReader.Value);
                            break;

                        case "LeftFontSize":
                            if (!xmlReader.Read()) return false;
                            LeftFontSize = int.Parse(xmlReader.Value);
                            break;

                        case "ListMaxCount":
                            if (!xmlReader.Read()) return false;
                            ListMaxCount = int.Parse(xmlReader.Value);
                            break;

                        case "Max":
                            if (!xmlReader.Read()) return false;
                            Max = int.Parse(xmlReader.Value);
                            break;

                        case "Min":
                            if (!xmlReader.Read()) return false;
                            Min = int.Parse(xmlReader.Value);
                            break;
                    }
                }
                else
                {
                    if (xmlReader.NodeType == XmlNodeType.EndElement)
                    {
                        if (xmlReader.Name == m_XMLName) break;
                    }
                }
            }
            return true;
        }

        public bool WriteInitFileToXML(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement(m_XMLName);
            xmlWriter.WriteElementString("TextColor", ColorToString(TextColor));
            xmlWriter.WriteElementString("CurrentDataColor", ColorToString(CurrentDataColor));
            xmlWriter.WriteElementString("BackgroundColor", ColorToString(BackgroundColor));
            xmlWriter.WriteElementString("GridColor", ColorToString(GridColor));
            xmlWriter.WriteElementString("SpecInColor", ColorToString(SpecInColor));
            xmlWriter.WriteElementString("SpecOutColor", ColorToString(SpecOutColor));
            xmlWriter.WriteElementString("WarningLineColor", ColorToString(WarningLineColor));
            xmlWriter.WriteElementString("AlarmLineColor", ColorToString(AlarmLineColor));
            xmlWriter.WriteElementString("GapX", GapX.ToString());
            xmlWriter.WriteElementString("GapY", GapY.ToString());
            xmlWriter.WriteElementString("IsViewModeLine", IsViewModeLine.ToString());
            xmlWriter.WriteElementString("IsLimitPeak", IsLimitPeak.ToString());
            xmlWriter.WriteElementString("FontSize", FontSize.ToString());
            xmlWriter.WriteElementString("LeftFontSize", LeftFontSize.ToString());
            xmlWriter.WriteElementString("ListMaxCount", ListMaxCount.ToString());
            xmlWriter.WriteElementString("Max", Max.ToString());
            xmlWriter.WriteElementString("Min", Min.ToString());

            xmlWriter.WriteEndElement();
            return true;
        }

        private string ColorToString(Color cr)
        {
            return string.Format("{0},{1},{2}", cr.R, cr.G, cr.B);
        }
    }
}