using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IRepository<T> 
    {
        IQueryable<T> AsQueryable();
        public Task<List<T>> GetAll();
        public Task<T> GetById(T entityObject);
        public Task<List<T>> InsertMany(List<T> entitiesObject);
        public Task<T> InsertOne(T entityObject);
        public Task<List<T>> UpdateMany(List<T> entitiesObject);
        public Task<T> UpdateOne(T entityObject);
        public Task<List<T>> DeleteMany(List<T> entitiesObject);
        public Task<T> DeleteOne(T entityObject);
    }
}
