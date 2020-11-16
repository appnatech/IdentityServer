using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace core.repository
{
    public interface IApiScopeRepository
    {
         Task<IEnumerable<ApiScope>> GetAllAsync();
         Task<IEnumerable<ApiScope>> GetByNameAsync(IEnumerable<string> scopeNames);
    }
}