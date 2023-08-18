using System;
using Newtonsoft.Json;

namespace Metalitix.Core.Data.Runtime
{
    [Serializable]
    public class MetricsData
    {
        public int fps { get; private set; }

        public MetricsData() { }

        [JsonConstructor]
        public MetricsData(int fps)
        {
            this.fps = fps;
        }

        public void SetFps(int fps)
        {
            this.fps = fps;
        }
    }
}