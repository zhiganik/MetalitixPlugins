using Newtonsoft.Json;

namespace Metalitix.Core.Data.InEditor
{
    public class ProjectFilters : BackendData
    {
        public ProjectFilter[] items { get; }

        [JsonConstructor]
        public ProjectFilters(ProjectFilter[] items, Pagination pagination) : base(pagination)
        {
            this.items = items;
        }
    }
}