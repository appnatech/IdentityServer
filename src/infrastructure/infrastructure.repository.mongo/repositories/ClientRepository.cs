using System.Threading.Tasks;
using application.core.repositories;
using IdentityServer4.Models;

namespace infrastructure.repository.mongo
{
    public class ClientMongoRepository:IClientRepository
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