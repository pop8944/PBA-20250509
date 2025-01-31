using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentFactory
{
    public class PBA_GerberInfo
    {
        public string LocationNo { get; set; }
        public string PosX { get; set; }
        public string PosY { get; set; }
        public string PosAngle { get; set; }
        public int ArrayIndex { get; set; }
        public string PartCode { get; set; }
        public bool Enabled { get; set; }
    }
}
