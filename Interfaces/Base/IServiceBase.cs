using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IServiceBase<T> where T : IEntityBase
    {
        public Task<string> GetAllEntity();
        public Task<string> GetByIdEntity(string entity);
        public Task<string> InsertManyEntity(string entities);
        public Task<string> InsertOneEntity(string entity);
        public Task<string> UpdateManyEntity(string entities);
        public Task<string> UpdateOneEntity(string entity);
        public Task<string> DeleteManyEntity(string entities);
        public Task<string> DeleteOneEntity(string entity);
    }
}
