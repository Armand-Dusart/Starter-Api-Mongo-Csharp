using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Attributes;
using WebApi.Interfaces;

namespace WebApi.Settings
{
    public class MongoDB : IMongoDB
    {
        private IMongoDatabase _db { get; set; }
        private IMongoClient _mongoClient { get; set; }
        public IClientSessionHandle Session { get; set; }

        public MongoDB(IOptions<Settings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            string name = (typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault() as BsonCollectionAttribute).CollectionName;
            return _db.GetCollection<T>(name);
        }


    }
}
