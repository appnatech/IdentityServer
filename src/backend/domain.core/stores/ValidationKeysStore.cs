using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Domain.Core.Stores
{
    public class ValidationKeysStore : IValidationKeysStore
    {
        private readonly IEnumerable<SecurityKeyInfo> _keys;

        public ValidationKeysStore(IEnumerable<SecurityKeyInfo> keys)
        {
            _keys = keys ?? throw new ArgumentNullException(nameof(keys));
        }

        public Task<IEnumerable<SecurityKeyInfo>> GetValidationKeysAsync()
        {
            return Task.FromResult(_keys);
        }
    }
}