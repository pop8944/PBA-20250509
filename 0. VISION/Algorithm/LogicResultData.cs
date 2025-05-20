using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentFactory
{
    public enum CoreKey {Pattern, Blob, Distance, Color, ColorEx, EYED, Condensor, Connector,Pin}

    public class LogicResultData
    {
        public CoreKey Key;
        public Dictionary<string, object> Data;
        public int ArrayIdx;
        public LogicResultData(CoreKey key, Dictionary<string, object> data, int arrayIdx)
        {
            Key = key;
            Data = data;
            ArrayIdx = arrayIdx;
        }
    }
}
