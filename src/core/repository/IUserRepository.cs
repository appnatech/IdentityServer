using System.Threading.Tasks;
using core.models;

namespace core.store
{
    public interface IUserRepository
    {
         Task<User> GetBySubjectyIdAsync(string subjectId);
         Task<User> GetByUsernameAsync(string userName);
         Task<User> GetByUsernameAndPasswordAsync(string username, string password);

         Task<User> AddAsync(User user);
    }
}