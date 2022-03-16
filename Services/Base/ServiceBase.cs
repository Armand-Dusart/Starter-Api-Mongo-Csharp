using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;
using WebApi.Repository;
using WebApi.Interfaces;
using Newtonsoft.Json;
using WebApi.Factory;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace WebApi.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : IEntityBase, new()
    {
        private readonly IRepositoryFactory<T, Repository<T>> RepositoryFactory;

        public ServiceBase(IRepositoryFactory<T,Repository<T>> repositoryFactory)
        {
            RepositoryFactory = repositoryFactory;
        }

        public async Task<string> GetByIdEntity(string id)
        {
            T result = await RepositoryFactory.Repository.GetById(JsonConvert.DeserializeObject<ObjectId>(id));

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
            List<T> result = await RepositoryFactory.Repository.InsertMany(JsonConvert.DeserializeObject<List<T>>(entities));

            return JsonConvert.SerializeObject(result);
        }
        
        public async Task<string> UpdateOneEntity(string entity)
        {
            T result = await RepositoryFactory.Repository.UpdateOne(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }

        public string UpdateManyEntity(string entities)
        {
            List<T> result = RepositoryFactory.Repository.UpdateMany(JsonConvert.DeserializeObject<List<T>>(entities));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> DeleteOneEntity(string id)
        {
            ObjectId result = await RepositoryFactory.Repository.DeleteOne(JsonConvert.DeserializeObject<ObjectId>(id));

            return JsonConvert.SerializeObject(result);
        }
        public async Task<string> DeleteManyEntity(string ids)
        {
            List<ObjectId> result = await RepositoryFactory.Repository.DeleteMany(JsonConvert.DeserializeObject<List<ObjectId>>(ids));

            return JsonConvert.SerializeObject(result);
        }
        public async  Task<string> FindManyEntity(Expression<Func<T, bool>> query)
        {
            List<T> result = await RepositoryFactory.Repository.FindMany(query);

            return JsonConvert.SerializeObject(result);
        }
        public async Task<string> FindOneEntity(Expression<Func<T, bool>> query)
        {
            T result = await  RepositoryFactory.Repository.FindOne(query);

            return JsonConvert.SerializeObject(result);
        }
    }
}
