using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace core.repository
{
    public interface IIdentityResourceRepository
    {
        Task<IEnumerable<IdentityResource>> GetAllAsync();
        Task<IEnumerable<IdentityResource>> GetByScopeNameAsync(IEnumerable<string> scopeNames);
    }
}