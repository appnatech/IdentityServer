using System.Threading.Tasks;
using Domain.Core.Repositories;
using IdentityServer4.Models;
using Infrastructure.Repository.Mongo.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repository.Mongo
{
    public class ClientMongoRepository : IClientRepository
    {
        private const string ApiScopeCollectionName = "Client";
        private readonly IMongoCollection<Client> _clients;

        public ClientMongoRepository(IOptions<MongoDataBaseConfigurations> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _clients = database.GetCollection<Client>(ApiScopeCollectionName);
        }

        public async Task<Client> AddAsync(Client client)
        {
            await _clients.InsertOneAsync(client);
            return client;
        }
        public async Task<Client> GetByClientIdAsync(string clientId)
        {
            var client = await _clients.FindAsync(c => c.ClientId == clientId);

            return await client.SingleOrDefaultAsync();
        }
    }
}