using Metalitix.Core.Data.Runtime;
using Newtonsoft.Json;

namespace Metalitix.Core.Data.InEditor
{
    public class HeatMapData : BackendData
    {
        public Record[] items { get; private set; }

        [JsonConstructor]
        public HeatMapData(Record[] items, Pagination pagination) : base(pagination)
        {
            this.items = items;
        }
    }
}