using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Infrastructure.Repository.Mongo.Config;
using MediatR;
using MongoDB.Driver;
namespace Application.Queries.User
{
    public class GetUsersQuery : BaseQuery<IEnumerable<Domain.Core.Models.User>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<Domain.Core.Models.User>>
    {
        private readonly IMongoDatabase database;
        private IMongoCollection<Domain.Core.Models.User> _users => database.GetCollection<Domain.Core.Models.User>("Users");

        public GetUsersQueryHandler(IOptions<MongoDataBaseConfigurations> config)
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            database = mongoClient.GetDatabase(config.Value.DatabaseName);
        }

        public async Task<IEnumerable<Domain.Core.Models.User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _users.FindAsync(user => true, null, cancellationToken);
            return await users.ToListAsync(cancellationToken);
        }
    }
}