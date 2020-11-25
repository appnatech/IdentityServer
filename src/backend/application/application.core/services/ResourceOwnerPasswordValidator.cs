using System;
using System.Threading.Tasks;
using application.core.repositories;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authentication;

namespace application.core.services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserRepository _userRepository;
        private readonly ISystemClock _clock;

        public ResourceOwnerPasswordValidator(ISystemClock clock, IUserRepository userRepository)
        {
            _clock = clock;
            _userRepository = userRepository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userRepository.GetByUsernameAndPasswordAsync(context.UserName, context.Password).ConfigureAwait(false);
            if (user != null)
            {
                if (user.SubjectId == null)
                    throw new ArgumentException("Subject Id not set", nameof(user.SubjectId));

                context.Result = new GrantValidationResult(user.SubjectId, OidcConstants.AuthenticationMethods.Password, _clock.UtcNow.UtcDateTime, user.Claims);
            }
        }
    }
}