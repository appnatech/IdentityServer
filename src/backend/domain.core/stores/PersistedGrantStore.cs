using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace domain.core.stores
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        public Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            throw new System.NotImplementedException();
        }
    }
}