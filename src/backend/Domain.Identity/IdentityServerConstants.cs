using System;

namespace Domain.Identity
{
    internal static class IdentityServerConstants
    {
        public static class ProtocolTypes
        {
            public const string OpenIdConnect = "oidc";
        }

        public static class SecretTypes
        {
            public const string SharedSecret = "SharedSecret";
        }
    }
}
