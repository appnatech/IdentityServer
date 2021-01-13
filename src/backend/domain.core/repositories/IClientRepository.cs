using System.Threading.Tasks;
using IdentityServer4.Models;

namespace Domain.Core.Repositories
{
    public interface IClientRepository
    {
        Task<Client> GetAsync(string id);
        Task<Client> AddAsync(Client user);
    }
}