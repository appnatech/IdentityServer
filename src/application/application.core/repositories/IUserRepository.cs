using System.Threading.Tasks;
using application.core.models;

namespace application.core.repositories
{
    public interface IUserRepository
    {
         Task<User> GetBySubjectyIdAsync(string subjectId);
         Task<User> GetByUsernameAsync(string userName);
         Task<User> GetByUsernameAndPasswordAsync(string username, string password);

         Task<User> AddAsync(User user);
    }
}