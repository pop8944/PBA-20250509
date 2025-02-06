using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFOnnxRuntime.DTOs
{
    public class DetectionResultDTO : BaseResultDTO
    {
        public (int X, int Y, int Width, int Height) Box { get; set; }
    }
}
