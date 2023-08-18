using System;

namespace Metalitix.Core.Data.Runtime
{
    [Serializable]
    public class MetalitixUserMetaData
    {
        public string sceneName { get; }
        public MetadataSystemInfo systemInfo { get; private set; }

        public MetalitixUserMetaData(string sceneName)
        {
            this.sceneName = sceneName;
        }

        public void SetSystemInfo(MetadataSystemInfo metadataSystemInfo)
        {
            systemInfo = metadataSystemInfo;
        }
    }
}