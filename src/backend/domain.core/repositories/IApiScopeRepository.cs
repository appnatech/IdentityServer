using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace domain.core.repositories
{
    public interface IApiScopeRepository
    {
        Task<IEnumerable<ApiScope>> GetAllAsync();
        Task<IEnumerable<ApiScope>> GetByNameAsync(IEnumerable<string> scopeNames);
    }
}