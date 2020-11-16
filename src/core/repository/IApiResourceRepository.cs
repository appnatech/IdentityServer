using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace core.repository
{
    public interface IApiResourceRepository
    {
         Task<IEnumerable<ApiResource>> GetAllAsync();
         Task<IEnumerable<ApiResource>> GetByNamesAsync(IEnumerable<string> apiResourceNames);
         Task<IEnumerable<ApiResource>> GetByScopeNameAsync(IEnumerable<string> scopeNames);
    }
}