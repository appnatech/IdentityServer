using System.Threading.Tasks;
using Domain.Core.Models;

namespace Domain.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetBySubjectIdAsync(string subjectId);
        Task<User> GetByUsernameAsync(string userName);
        Task<User> GetByUsernameAndPasswordAsync(string username, string password);

        Task<User> AddAsync(User user);
    }
}