using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFOnnxRuntime.Models
{
    public class OnnxMetaData
    {
        public string Task { get; set; }
        public int BatchSize { get; set; }
        public Size Size { get; set; }
        public Dictionary<int, string> Classes { get; set; }

    }
}
