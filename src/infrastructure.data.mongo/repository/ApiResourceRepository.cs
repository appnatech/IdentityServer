using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.repository;
using IdentityServer4.Models;
using infrastructure.data.mongo.config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace infrastructure.data.mongo.repository
{
    public class ApiResourceMongoRepository : IApiResourceRepository
    {

        private const string ApiResourceCollectionName = "ApiResource";
        private readonly IMongoCollection<ApiResource> _apiResourses;

        public ApiResourceMongoRepository(IOptions<MongoDataBaseConfigurations> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);
            
            _apiResourses = database.GetCollection<ApiResource>(ApiResourceCollectionName);   
        }

        public async Task<IEnumerable<ApiResource>> GetAllAsync()
        {
            var apiResources= await _apiResourses.FindAsync(apiResource=>true);
            return apiResources.ToList();
        }

        public async Task<IEnumerable<ApiResource>> GetByNamesAsync(IEnumerable<string> apiResourceNames)
        {
              var apiResources= await _apiResourses.FindAsync(apiResource=>apiResourceNames.Contains(apiResource.Name));
              return apiResources.ToList();
        }

        public  async Task<IEnumerable<ApiResource>> GetByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var apiResources=await _apiResourses.FindAsync(apiResource=>apiResource.Scopes.Any(scope=>scopeNames.Contains(scope)));
            return apiResources.ToList();
        }
    }
}