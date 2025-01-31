using Cognex.VisionPro;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class Recipe_Insp
    {
        public Rectangle QrRegionArray1 { get; set; } = new Rectangle(100, 100, 100, 100);
        public Rectangle QrRegionArray2 { get; set; } = new Rectangle(100, 100, 100, 100);
        public Rectangle QrRegionArray3 { get; set; } = new Rectangle(100, 100, 100, 100);
        public Rectangle QrRegionArray4 { get; set; } = new Rectangle(100, 100, 100, 100);

        public Recipe_Insp()
        {
        }

        public Recipe_Insp Load(string recipeName)
        {
            string path = $"{Application.StartupPath}\\RECIPE\\{recipeName}\\Recipe_Insp.xml";
            Recipe_Insp newData = null;

            if (File.Exists(path))
            {
                newData = SerializeHelper.FromXmlFile<Recipe_Insp>(path);

                if (newData != null)
                {

                    return newData;
                }
            }

            newData = new Recipe_Insp();
            newData.Save(recipeName);
            return newData;
        }

        public CogRectangle GetQrCogRegion(int idx)
        {
            if (idx == 0) return CConverter.RectToCogRect(QrRegionArray1);
            if (idx == 1) return CConverter.RectToCogRect(QrRegionArray2);
            if (idx == 2) return CConverter.RectToCogRect(QrRegionArray3);
            if (idx == 3) return CConverter.RectToCogRect(QrRegionArray4);

            return new CogRectangle();
        }

        public Rectangle GetQrRegion(int idx)
        {
            if (idx == 0) return QrRegionArray1;
            if (idx == 1) return QrRegionArray2;
            if (idx == 2) return QrRegionArray3;
            if (idx == 3) return QrRegionArray4;

            return new Rectangle();
        }

        public void Save(string recipeName)
        {
            string path = $"{Application.StartupPath}\\RECIPE\\{recipeName}\\Recipe_Insp.xml";
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            try { SerializeHelper.ToXmlFile(path, this); } catch (Exception ex) { }
        }
    }
}
