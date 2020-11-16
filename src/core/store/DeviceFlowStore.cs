using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace core.store
{
    public class DeviceFlowStore : IDeviceFlowStore
    {
        public Task<DeviceCode> FindByDeviceCodeAsync(string deviceCode)
        {
            throw new System.NotImplementedException();
        }

        public Task<DeviceCode> FindByUserCodeAsync(string userCode)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveByDeviceCodeAsync(string deviceCode)
        {
            throw new System.NotImplementedException();
        }

        public Task StoreDeviceAuthorizationAsync(string deviceCode, string userCode, DeviceCode data)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateByUserCodeAsync(string userCode, DeviceCode data)
        {
            throw new System.NotImplementedException();
        }
    }
}