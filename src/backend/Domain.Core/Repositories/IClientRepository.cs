using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Domain.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetByClientIdAsync(string clientId);
        Task<Client> AddAsync(Client user);
    }
}