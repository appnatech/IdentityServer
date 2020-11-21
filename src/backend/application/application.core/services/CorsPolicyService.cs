using System.Threading.Tasks;
using IdentityServer4.Services;

namespace application.core.services
{
    public class CorsPolicyService : ICorsPolicyService
    {
        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            return Task.FromResult(true);
        }
    }
}