using System.Threading.Tasks;
using core.models;
using core.store;

namespace infrastructure.data.mongo.repository
{
    public class UserMongoRepository : IUserRepository
    {
        public Task<User> AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetBySubjectyIdAsync(string subjectId)
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