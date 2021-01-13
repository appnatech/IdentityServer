using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Domain.Core.Stores
{
    public class ResourcesStore : IResourceStore
    {
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IApiScopeRepository _apiScopeRepository;
        private readonly IIdentityResourceRepository _identityResourceRepository;

        public ResourcesStore(IApiScopeRepository apiScopeRepository, IApiResourceRepository apiResourceRepository, IIdentityResourceRepository identityResourceRepository)
        {
            _apiScopeRepository = apiScopeRepository;
            _apiResourceRepository = apiResourceRepository;
            _identityResourceRepository = identityResourceRepository;
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            if (apiResourceNames == null)
                throw new ArgumentNullException(nameof(apiResourceNames));

            return _apiResourceRepository.GetByNamesAsync(apiResourceNames);
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null)
                throw new ArgumentNullException(nameof(scopeNames));

            return _apiResourceRepository.GetByScopeNameAsync(scopeNames);
        }

        public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null)
                throw new ArgumentNullException(nameof(scopeNames));

            return _apiScopeRepository.GetByNameAsync(scopeNames);
        }

        public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            if (scopeNames == null)
                throw new ArgumentNullException(nameof(scopeNames));

            return _identityResourceRepository.GetByScopeNameAsync(scopeNames);
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            Task<IEnumerable<ApiResource>> apiResourceResult = _apiResourceRepository.GetAllAsync();
            Task<IEnumerable<ApiScope>> apiScopeResult = _apiScopeRepository.GetAllAsync();
            Task<IEnumerable<IdentityResource>> identityResourceResult = _identityResourceRepository.GetAllAsync();

            Task.WaitAll(new Task[]
            {
                apiResourceResult,
                apiScopeResult,
                identityResourceResult
            });

            var result = new Resources(identityResourceResult.Result, apiResourceResult.Result, apiScopeResult.Result);

            return Task.FromResult(result);
        }
    }
}