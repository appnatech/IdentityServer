using System.Threading.Tasks;
using core.repository;
using IdentityServer4.Models;

namespace infrastructure.data.mongo.repository
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