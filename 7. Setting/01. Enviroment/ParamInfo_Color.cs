using System;
using System.Collections.Generic;
using System.Drawing;

namespace IntelligentFactory
{
    [Serializable]
    public class ParamInfo_Color
    {
        public List<ColorNode> ColorNodes { get; set; } = new List<ColorNode>();

        public ParamInfo_Color()
        {
        }

        public void AddColor(string name, int minR, int minG, int minB, int maxR, int maxG, int maxB)
        {
            ColorNodes.Add(new ColorNode(name, minR, minG, minB, maxR, maxG, maxB));
        }

        public string ExtractColorName(int r, int g, int b)
        {
            string name = "";
            for (int i = 0; i < ColorNodes.Count; i++)
            {
                if (ColorNodes[i].InRange(r, g, b))
                {
                    return ColorNodes[i].Name;
                }
            }

            return name;
        }
    }

    [Serializable]
    public class ColorNode
    {
        public int MinR { get; set; }
        public int MinG { get; set; }
        public int MinB { get; set; }

        public int MaxR { get; set; }
        public int MaxG { get; set; }
        public int MaxB { get; set; }

        public string Name { get; set; }

        public Color Color
        {
            get => Color.FromArgb((MinR + MaxR) / 2, (MinG + MaxG) / 2, (MinB + MaxB) / 2);
        }

        public Color MinColor
        {
            get => Color.FromArgb(MinR, MinG, MinB);
        }

        public Color MaxColor
        {
            get => Color.FromArgb(MaxR, MaxG, MaxB);
        }

        public ColorNode(string name, int minR, int minG, int minB, int maxR, int maxG, int maxB)
        {
            Name = name;

            MinR = minR;
            MinG = minG;
            MinB = minB;

            MaxR = maxR;
            MaxG = maxG;
            MaxB = maxB;

            if (MinR < 0) MinR = 0;
            if (MinR > 255) MinR = 255;

            if (MinG < 0) MinG = 0;
            if (MinG > 255) MinG = 255;

            if (MinB < 0) MinB = 0;
            if (MinB > 255) MinB = 255;

            if (MaxR < 0) MaxR = 0;
            if (MaxR > 255) MaxR = 255;

            if (MaxG < 0) MaxG = 0;
            if (MaxG > 255) MaxG = 255;

            if (MaxB < 0) MaxB = 0;
            if (MaxB > 255) MaxB = 255;
        }

        public bool InRange(int r, int g, int b)
        {
            return r >= MinR && r <= MaxR &&
                   g >= MinG && g <= MaxG &&
                   b >= MinB && b <= MaxB;
        }
    }
}
