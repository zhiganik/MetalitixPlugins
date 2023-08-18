using System;

namespace Metalitix.Core.Data.Kinesis
{
    [Serializable]
    public class KinesisAuthData
    {
        public string appkey { get; }

        public KinesisAuthData(string appKey)
        {
            appkey = appKey;
        }
    }
}