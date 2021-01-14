using System.Threading.Tasks;
using Domain.Core.Repositories;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Domain.Core.Stores
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
            return _clientRepository.GetByClientIdAsync(clientId);
        }
    }
}