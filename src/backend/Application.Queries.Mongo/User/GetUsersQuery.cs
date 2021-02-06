using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Queries.Models;
using Global.Mongo.Models;
using Infrastructure.Repository.Mongo.Config;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
namespace Application.Queries.User
{
    public class GetUsersQuery : BaseQuery<IEnumerable<UserViewModel>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserViewModel>>
    {
        private readonly IMongoDatabase database;
        private readonly IMongoCollection<UserDocument> _users;

        public GetUsersQueryHandler(IOptions<MongoDataBaseConfigurations> config)
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            database = mongoClient.GetDatabase(config.Value.DatabaseName);

            _users = database.GetCollection<UserDocument>("Users");
        }

        public async Task<IEnumerable<UserViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            IAsyncCursor<UserDocument> userDocumentCursor = await _users.FindAsync(w => true, cancellationToken: cancellationToken);
            var userDocuments = userDocumentCursor.ToList(cancellationToken: cancellationToken);

            return userDocuments.Select(s => new UserViewModel()
            {
                UserName = s.Username,
                Name = s.Name,
                IsActive = s.IsActive
            });
        }
    }
}