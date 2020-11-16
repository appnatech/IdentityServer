using System.Threading.Tasks;
using core.repository;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace core.store
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