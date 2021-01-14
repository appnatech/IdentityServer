using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using IdentityServer4.Models;
using Infrastructure.Repository.Mongo.Config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repository.Mongo
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
            IAsyncCursor<IdentityResource> identityResources = await _identityResources.FindAsync(identityResource => true);
            return identityResources.ToList();
        }

        public async Task<IEnumerable<IdentityResource>> GetByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            IAsyncCursor<IdentityResource> identityResources = await _identityResources
                                                                .FindAsync(resource => scopeNames.Contains(resource.Name));
            return identityResources.ToList();
        }
    }
}
}