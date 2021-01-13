using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Domain.Core.Repositories
{
    public interface IIdentityResourceRepository
    {
        Task<IEnumerable<IdentityResource>> GetAllAsync();
        Task<IEnumerable<IdentityResource>> GetByScopeNameAsync(IEnumerable<string> scopeNames);
    }
}