using System.Threading.Tasks;
using domain.core.repositories;
using IdentityServer4.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using infrastructure.repository.mongo.config;
using System;

namespace infrastructure.repository.mongo
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

        public Task<Client> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}