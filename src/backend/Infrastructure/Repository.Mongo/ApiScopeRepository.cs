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
    public class ApiScopeMongoRepository : IApiScopeRepository
    {
        private const string ApiScopeCollectionName = "ApiScope";
        private readonly IMongoCollection<ApiScope> _apiScopes;

        public ApiScopeMongoRepository(IOptions<MongoDataBaseConfigurations> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _apiScopes = database.GetCollection<ApiScope>(ApiScopeCollectionName);
        }

        public async Task<IEnumerable<ApiScope>> GetAllAsync()
        {
            IAsyncCursor<ApiScope> apiScopes = await _apiScopes.FindAsync(apiResource => true);
            return apiScopes.ToList();
        }

        public async Task<IEnumerable<ApiScope>> GetByNameAsync(IEnumerable<string> scopeNames)
        {
            IAsyncCursor<ApiScope> apiScopes = await _apiScopes.FindAsync(apiScope => scopeNames.Contains(apiScope.Name));
            return apiScopes.ToList();
        }
    }
}