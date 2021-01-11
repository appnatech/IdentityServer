using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using domain.core.models;
using domain.core.repositories;
using infrastructure.repository.mongo.config;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace infrastructure.repository.mongo
{
    public class UserMongoRepository : IUserRepository
    {
        private const string IdentityResourceCollectionName = "Users";
        private readonly IMongoCollection<User> _users;

        public UserMongoRepository(IOptions<MongoDataBaseConfigurations> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _users = database.GetCollection<User>(IdentityResourceCollectionName);
        }


        public async Task<User> AddAsync(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<User> GetBySubjectIdAsync(string subjectId)
        {
            IAsyncCursor<User> user = await _users.FindAsync(w => w.SubjectId == subjectId);
            return user.SingleOrDefault();
        }

        public Task<User> GetByUsernameAndPasswordAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByUsernameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}