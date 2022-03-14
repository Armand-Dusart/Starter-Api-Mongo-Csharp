using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Settings;

namespace WebApi.Repository
{
    public class Repository<T> : IRepository<T> where T:IEntityBase
    {
        protected readonly IMongoDB _mongoContext;
        protected IMongoCollection<T> _dbCollection;

        public Repository (IMongoDB context)
        {
                _mongoContext = context;
                _dbCollection = _mongoContext.GetCollection<T>(typeof(T).Name);
        }

        async public Task<List<T>> GetAll()
        {
            return (List<T>)await _dbCollection.FindAsync(Builders<T>.Filter.Empty);
        }

        async public Task<T> GetById(T entityObject)
        {
            return await _dbCollection.Find((T doc) => doc.Id == entityObject.Id).FirstOrDefaultAsync();
        }

        async public Task<List<T>> InsertMany(List<T> entityObjects)
        {
            await _dbCollection.InsertManyAsync(entityObjects);

            return entityObjects;
        }

        async public Task<T> InsertOne(T entityObject)
        {
            await _dbCollection.InsertOneAsync(entityObject);

            return entityObject;
        }

        public Task<List<T>> UpdateMany(List<T> entitiesObject)
        {
            throw new NotImplementedException();
        }

        async public Task<T> UpdateOne (T entityObject)
        {
            await _dbCollection.ReplaceOneAsync((T doc) => doc.Id == entityObject.Id, entityObject);

            return entityObject;
        }

        public Task<List<T>> DeleteMany(List<T> Entities)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteOne(T Entity)
        {
            throw new NotImplementedException();
        }
    }
}
