using System.Collections.Generic;
using Metalitix.Core.Data.Runtime;

namespace Metalitix.Core.Data.InEditor
{
    public class LoadedDataInfo
    {
        public List<Record> Records { get; }
        public DataRequest Request { get; }

        public LoadedDataInfo(List<Record> records, DataRequest request)
        {
            Records = records;
            Request = request;
        }
    }
}