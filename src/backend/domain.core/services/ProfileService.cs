using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace Domain.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;

        public ProfileService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            if (context.RequestedClaimTypes.Any())
            {
                var user = await _userRepository.GetBySubjectIdAsync(context.Subject.GetSubjectId());
                if (user != null)
                {
                    context.AddRequestedClaims(user.Claims);
                }
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var user = await _userRepository.GetBySubjectIdAsync(context.Subject.GetSubjectId());
            context.IsActive = user?.IsActive == true;
        }
    }
}