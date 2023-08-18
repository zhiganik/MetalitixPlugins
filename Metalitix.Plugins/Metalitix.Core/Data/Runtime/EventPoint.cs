using System;
using Metalitix.Core.Data.Containers;
using Metalitix.Core.Data.Converters;
using Metalitix.Core.Enums.Runtime;
using UnityEngine;

namespace Metalitix.Core.Data.Runtime
{
    [Serializable]
    public class EventPoint
    {
        public string state { get; }
        public long timestamp { get; }
        public Vector3Wrapper position { get; }

        public EventPoint(PointStates state, long timestamp, Vector3 position)
        {
            this.state = MetalitixPointStatesContainer.GetConstant(state);
            this.timestamp = timestamp;
            this.position = new Vector3Wrapper(position);
        }
    }
}