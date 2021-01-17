using System;
using Infrastructure.Repository.Mongo.Models;
using MongoDB.Bson.Serialization;

namespace Infrastructure.Repository.Mongo
{
    public class RepositoryBase
    {
        static RepositoryBase()
        {
            BsonClassMap.RegisterClassMap<UserDocument>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });
        }
    }
}
