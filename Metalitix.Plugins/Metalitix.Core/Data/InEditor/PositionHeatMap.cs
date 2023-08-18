using System;
using System.Collections.Generic;

namespace Metalitix.Core.Data.InEditor
{
    [Serializable]
    public class PositionHeatMap
    {
        public Dictionary<string, int> indicators { get; }

        public PositionHeatMap(Dictionary<string, int> indicators)
        {
            this.indicators = indicators;
        }
    }
}