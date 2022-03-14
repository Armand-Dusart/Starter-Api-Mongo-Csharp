using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Attributes;
using WebApi.Interfaces;
using WebApi.Settings;

namespace WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T : IEntityBase
    {
        protected IMongoCollection<T> _collection;

        public Repository(ISettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }


        public virtual IQueryable<T> AsQueryable()
        {
            return _collection.AsQueryable();
        }


        public async virtual  Task<List<T>> GetAll()
        {
            return (List<T>)await _collection.FindAsync(Builders<T>.Filter.Empty);
        }

        public async virtual  Task<T> GetById(T entityObject)
        {
            return await _collection.Find((T doc) => doc.Id == entityObject.Id).FirstOrDefaultAsync();
        }

        public async virtual Task<List<T>> InsertMany(List<T> entityObjects)
        {
            await _collection.InsertManyAsync(entityObjects);

            return entityObjects;
        }

        public async virtual  Task<T> InsertOne(T entityObject)
        {
            await _collection.InsertOneAsync(entityObject);

            return entityObject;
        }

        public async virtual Task<List<T>> UpdateMany(List<T> entitiesObject)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> UpdateOne (T entityObject)
        {
            await _collection.ReplaceOneAsync((T doc) => doc.Id == entityObject.Id, entityObject);

            return entityObject;
        }

        public async virtual Task<List<T>> DeleteMany(List<T> Entities)
        {
            throw new NotImplementedException();
        }

        public async virtual Task<T> DeleteOne(T Entity)
        {
            throw new NotImplementedException();
        }

    }
}
