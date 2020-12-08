using System.Threading.Tasks;
using IdentityServer4.Stores;
using Microsoft.IdentityModel.Tokens;

namespace domain.core.stores
{
    public class SigningCredentialStore : ISigningCredentialStore
    {
        private readonly SigningCredentials _credentials;

        public SigningCredentialStore(SigningCredentials credentials)
        {
            _credentials = credentials;
        }

        public Task<SigningCredentials> GetSigningCredentialsAsync()
        {
            return Task.FromResult(_credentials);
        }
    }
}