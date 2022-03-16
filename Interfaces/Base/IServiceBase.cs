using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IServiceBase<T> where T : IEntityBase
    {
        public Task<string> GetAllEntity();
        public Task<string> GetByIdEntity(string id);
        public Task<string> InsertManyEntity(string entities);
        public Task<string> InsertOneEntity(string entity);
        public string UpdateManyEntity(string entities);
        public Task<string> UpdateOneEntity(string entity);
        public Task<string> DeleteManyEntity(string ids);
        public Task<string> DeleteOneEntity(string id);
        public Task<string> FindManyEntity(Expression<Func<T, bool>> query);
        public Task<string> FindOneEntity(Expression<Func<T, bool>> query);
    }
}
