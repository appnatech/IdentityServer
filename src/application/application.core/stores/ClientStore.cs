using System.Threading.Tasks;
using application.core.repositories;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace application.core.stores
{
    public class ClientStore : IClientStore
    {
        private readonly IClientRepository _clientRepository;
        public ClientStore(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            return _clientRepository.GetAsync(clientId);
        }
    }

    
}