using System.Threading.Tasks;
using domain.core.models;

namespace domain.core.repositories
{
    public interface IUserRepository
    {
        Task<User> GetBySubjectIdAsync(string subjectId);
        Task<User> GetByUsernameAsync(string userName);
        Task<User> GetByUsernameAndPasswordAsync(string username, string password);

        Task<User> AddAsync(User user);
    }
}