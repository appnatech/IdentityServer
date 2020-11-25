using System.Threading.Tasks;
using application.core.models;
using application.core.repositories;

namespace infrastructure.repository.mongo
{
    public class UserMongoRepository : IUserRepository
    {
        public Task<User> AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetBySubjectIdAsync(string subjectId)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByUsernameAndPasswordAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByUsernameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ValidateCredentialsAsync(string username, string password, out User user)
        {
            throw new System.NotImplementedException();
        }
    }
}