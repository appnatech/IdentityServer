using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.core.repositories;
using IdentityServer4.Models;
using infrastructure.repository.mongo.config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace infrastructure.repository.mongo
{
    public class IdentityResourceMongoRepository : IIdentityResourceRepository
    {
        private const string IdentityResourceCollectionName = "IdentityResource";
        private readonly IMongoCollection<IdentityResource> _identityResources;

        public IdentityResourceMongoRepository(IOptions<MongoDataBaseConfigurations> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _identityResources = database.GetCollection<IdentityResource>(IdentityResourceCollectionName);
        }

        public async Task<IEnumerable<IdentityResource>> GetAllAsync()
        {
            IAsyncCursor<IdentityResource> identityResources= await _identityResources.FindAsync(identityResource=>true);
            return identityResources.ToList();
        }

        public Task<IEnumerable<IdentityResource>> GetByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }
    }
}