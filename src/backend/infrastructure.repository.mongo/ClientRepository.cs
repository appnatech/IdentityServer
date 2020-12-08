using System.Threading.Tasks;
using domain.core.repositories;
using IdentityServer4.Models;

namespace infrastructure.repository.mongo
{
    public class ClientMongoRepository : IClientRepository
    {
        public Task<Client> AddAsync(Client user)
        {
            throw new System.NotImplementedException();
        }

        public Task<Client> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}