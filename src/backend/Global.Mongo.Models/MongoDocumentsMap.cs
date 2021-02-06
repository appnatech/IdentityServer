using System;
using MongoDB.Bson.Serialization;

namespace Global.Mongo.Models
{
    public class MongoDocumentsMap
    {
        public static void Initialize()
        {
            BsonClassMap.RegisterClassMap<UserDocument>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });
        }
    }
}
