using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;
using WebApi.Repository;
using WebApi.Interfaces;
using Newtonsoft.Json;
using WebApi.Factory;

namespace WebApi.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : IEntityBase, new()
    {
        private readonly IRepositoryFactory<T, Repository<T>> RepositoryFactory;

        public ServiceBase(IRepositoryFactory<T,Repository<T>> repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;
        }

        public async Task<string> GetByIdEntity(string entity)
        {
            T result = await RepositoryFactory.Repository.GetById(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> GetAllEntity()
        {
            object result = await RepositoryFactory.Repository.GetAll();

            return JsonConvert.SerializeObject(result);
        }
        
        public async Task<string> InsertOneEntity(string entity)
        {
            T result = await RepositoryFactory.Repository.InsertOne(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> InsertManyEntity(string entities)
        {
            List<T> result = await RepositoryFactory.Repository.UpdateMany(JsonConvert.DeserializeObject<List<T>>(entities));

            return JsonConvert.SerializeObject(result);
        }
        
        public async Task<string> UpdateOneEntity(string entity)
        {
            T result = await RepositoryFactory.Repository.UpdateOne(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> UpdateManyEntity(string entities)
        {
            List<T> result = await RepositoryFactory.Repository.UpdateMany(JsonConvert.DeserializeObject<List<T>>(entities));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> DeleteOneEntity(string entity)
        {
            T result = await RepositoryFactory.Repository.DeleteOne(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }
        public async Task<string> DeleteManyEntity(string entities)
        {
            List<T> result = await RepositoryFactory.Repository.DeleteMany(JsonConvert.DeserializeObject<List<T>>(entities));

            return JsonConvert.SerializeObject(result);
        }
        
    }
}
