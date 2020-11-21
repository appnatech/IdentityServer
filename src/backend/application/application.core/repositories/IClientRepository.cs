using System.Threading.Tasks;
using IdentityServer4.Models;

namespace application.core.repositories
{
    public interface IClientRepository
    {
        Task<Client> GetAsync(string id);
        Task<Client> AddAsync(Client user);
    }
}