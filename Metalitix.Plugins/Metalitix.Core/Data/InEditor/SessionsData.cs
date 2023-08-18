using System;
using Metalitix.Core.Data.Runtime;
using Newtonsoft.Json;

namespace Metalitix.Core.Data.InEditor
{
    [Serializable]
    public class SessionsData : BackendData
    {
        public SessionData[] items { get; private set; }

        [JsonConstructor]
        public SessionsData(SessionData[] items, Pagination pagination) : base(pagination)
        {
            this.items = items;
        }
    }
}