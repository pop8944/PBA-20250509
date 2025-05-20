using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Recipe_Insp
    {
        List<Rectangle> QRRegionArrayList = new List<Rectangle>();

        public List<Rectangle> QrRegionList { get; set; }
        public Recipe_Insp()
        {
            QrRegionList = new List<Rectangle>();
            int defaultNumberOfRegions = 12;
            for (int i = 0; i < defaultNumberOfRegions; i++)
            {
                QrRegionList.Add(new Rectangle(100, 100, 100, 100));
            }
        }

        public Rectangle GetQrRegion(int index)
        {
            if (index >= 0 && index < QrRegionList.Count)
            {
                return QrRegionList[index];
            }
            else
            {
                return Rectangle.Empty;
            }
        }

        public CogRectangle GetQrCogRegion(int idx)
        {
            Rectangle region = GetQrRegion(idx);
            if (!region.IsEmpty)
            {
                return CConverter.RectToCogRect(region);
            }
            return new CogRectangle();
        }
        public void SetQrRegion(int index, Rectangle value)
        {
            if (index >= 0 && index < QrRegionList.Count)
            {
                QrRegionList[index] = value;
            }
            else
            {

            }
        }
    }
}
