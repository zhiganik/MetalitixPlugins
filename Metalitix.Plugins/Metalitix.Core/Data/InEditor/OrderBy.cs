using System;
using Metalitix.Core.Enums.InEditor;

namespace Metalitix.Core.Data.InEditor
{
    public class OrderBy
    {
        private OrderByType orderByType;
        private bool isDescending;

        public OrderBy(OrderByType orderByType, bool isDescending = false)
        {
            this.orderByType = orderByType;
            this.isDescending = isDescending;
        }

        public string GetOrder()
        {
            var sign = isDescending ? "-" : string.Empty;
            var value = sign + Enum.GetName(typeof(OrderByType), orderByType);
            return value;
        }
    }
}