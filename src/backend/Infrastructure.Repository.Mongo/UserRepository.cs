using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Core.Models;
using Domain.Core.Repositories;
using IdentityModel;
using Infrastructure.Repository.Mongo.Config;
using Infrastructure.Repository.Mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repository.Mongo
{
    public class UserMongoRepository : IUserRepository
    {
        private const string IdentityResourceCollectionName = "Users";
        private readonly IMongoCollection<UserDocument> _users;

        public UserMongoRepository(IOptions<MongoDataBaseConfigurations> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _users = database.GetCollection<UserDocument>(IdentityResourceCollectionName);
        }

        public async Task<User> AddAsync(User user)
        {
            // todo:save all claim in automate flow
            await _users.InsertOneAsync(new UserDocument()
            {
                SubjectId = user.SubjectId,
                Username = user.Username,
                Password = user.Password,
                IsActive = user.IsActive,
                Name = user.Claims.SingleOrDefault(s => s.Type == JwtClaimTypes.Name).Value
            })
            .ConfigureAwait(false);
            return user;
        }

        public Task UpdateAsync(string id, User user)
        {
            //return _users.ReplaceOneAsync(u => u.SubjectId == id, user);

            throw new System.NotImplementedException();
        }

        public async Task<User> GetBySubjectIdAsync(string subjectId)
        {
            IAsyncCursor<UserDocument> userDocumentCursor = await _users.FindAsync(w => w.SubjectId == subjectId);
            var userDocument = userDocumentCursor.SingleOrDefault();
            var user = new User()
            {
                Username = userDocument.Username,
                Password = userDocument.Password,
                IsActive = userDocument.IsActive,
                SubjectId = userDocument.SubjectId,
            };

            user.Claims.Add(new Claim(JwtClaimTypes.Name, userDocument.Name));

            return user;
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