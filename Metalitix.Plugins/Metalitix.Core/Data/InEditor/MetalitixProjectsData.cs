using System;
using Newtonsoft.Json;

namespace Metalitix.Core.Data.InEditor
{
    [Serializable]
    public class MetalitixProjectsData : BackendData
    {
        public MetalitixProjectData[] items { get; private set; }

        [JsonConstructor]
        public MetalitixProjectsData(MetalitixProjectData[] items, Pagination pagination) : base(pagination)
        {
            this.items = items;
        }
    }
}