using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Models;
using WebApi.Repository;
using WebApi.Interfaces;
using Newtonsoft.Json;

namespace WebApi.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : EntityBase
    {
        private readonly Repository<T> _repository;

        public ServiceBase(Repository<T> repository)
        {
            _repository = repository;
        }

        public async Task<string> GetByIdEntity(string entity)
        {
            T result = await _repository.GetById(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> GetAllEntity()
        {
            List<T> result = await _repository.GetAll();

            return JsonConvert.SerializeObject(result);
        }
        
        public async Task<string> InsertOneEntity(string entity)
        {
            T result = await _repository.InsertOne(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> InsertManyEntity(string entities)
        {
            List<T> result = await _repository.UpdateMany(JsonConvert.DeserializeObject<List<T>>(entities));

            return JsonConvert.SerializeObject(result);
        }
        
        public async Task<string> UpdateOneEntity(string entity)
        {
            T result = await _repository.UpdateOne(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> UpdateManyEntity(string entities)
        {
            List<T> result = await _repository.UpdateMany(JsonConvert.DeserializeObject<List<T>>(entities));

            return JsonConvert.SerializeObject(result);
        }

        public async Task<string> DeleteOneEntity(string entity)
        {
            T result = await _repository.DeleteOne(JsonConvert.DeserializeObject<T>(entity));

            return JsonConvert.SerializeObject(result);
        }
        public async Task<string> DeleteManyEntity(string entities)
        {
            List<T> result = await _repository.DeleteMany(JsonConvert.DeserializeObject<List<T>>(entities));

            return JsonConvert.SerializeObject(result);
        }
        
    }
}
