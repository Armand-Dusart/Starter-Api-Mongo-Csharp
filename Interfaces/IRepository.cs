using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IRepository<T> 
    {
        IQueryable<T> AsQueryable();
        public Task<object> GetAll();
        public Task<T> GetById(ObjectId id);
        public Task<List<T>> InsertMany(List<T> entitiesObject);
        public Task<T> InsertOne(T entityObject);
        public List<T> UpdateMany(List<T> entitiesObject);
        public Task<T> UpdateOne(T entityObject);
        public Task<List<ObjectId>> DeleteMany(List<ObjectId> ids);
        public Task<ObjectId> DeleteOne(ObjectId id);
        Task<List<T>> FindMany(Expression<Func<T, bool>> query);
        Task<T> FindOne(Expression<Func<T, bool>> query);
    }
}
