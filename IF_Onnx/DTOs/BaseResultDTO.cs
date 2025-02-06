using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFOnnxRuntime.DTOs
{
    public abstract class BaseResultDTO
    {
        public string Class { get; set; }
        public float Score { get; set; }

    }
}
