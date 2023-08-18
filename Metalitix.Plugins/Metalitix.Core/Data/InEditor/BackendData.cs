using System;

namespace Metalitix.Core.Data.InEditor
{
    [Serializable]
    public class BackendData
    {
        public Pagination pagination { get; private set; }

        public BackendData(Pagination pagination)
        {
            this.pagination = pagination;
        }
    }
}