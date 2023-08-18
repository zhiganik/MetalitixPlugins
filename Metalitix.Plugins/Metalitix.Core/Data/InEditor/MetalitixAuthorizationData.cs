using System;

namespace Metalitix.Core.Data.InEditor
{
    [Serializable]
    public class MetalitixAuthorizationData
    {
        public string email { get; private set; }
        public string password { get; private set; }

        public MetalitixAuthorizationData(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}