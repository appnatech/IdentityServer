using System.Threading.Tasks;
using IdentityServer4.Models;

namespace core.repository
{
    public interface IClientRepository
    {
        Task<Client> GetAsync(string id);
        Task<Client> AddAsync(Client user);
    }
}