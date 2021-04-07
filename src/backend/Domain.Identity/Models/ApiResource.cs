using System;
using System.Collections.Generic;
using Domain.Core.Extensions;

namespace Domain.Identity.Models
{
    public class ApiResource : Models.Resource
    {
        public ApiResource()
        {
        }

        public ApiResource(string name) : this(name, name, null)
        {
        }

        public ApiResource(string name, string displayName) : this(name, displayName, null)
        {
        }

        public ApiResource(string name, IEnumerable<string> userClaims) : this(name, name, userClaims)
        {
        }

        public ApiResource(string name, string displayName, IEnumerable<string> userClaims)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            DisplayName = displayName;

            if (!userClaims.IsNullOrEmpty())
            {
                foreach (var type in userClaims)
                {
                    UserClaims.Add(type);
                }
            }
        }

        public ICollection<Secret> ApiSecrets { get; set; } = new HashSet<Secret>();
        public ICollection<string> Scopes { get; set; } = new HashSet<string>();
        public ICollection<string> AllowedAccessTokenSigningAlgorithms { get; set; } = new HashSet<string>();
    }
}
