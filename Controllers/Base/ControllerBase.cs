using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Factory;
using WebApi.Services;

namespace WebApi.Controllers
{
    public abstract class ControllerBase<T,S> : Controller where T:IEntityBase where S : IServiceBase<T>
    {
        public IServiceFactory<T,S> _serviceFactory;

        public ControllerBase(IServiceFactory<T,S> serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAll()
        {
            string result = await _serviceFactory.Service.GetAllEntity();

            return result;
        }
        [HttpGet("GetById/{id}")]
        public async Task<string> GetById(string id)
        {
            string result = await _serviceFactory.Service.GetByIdEntity(id);

            return result;
        }

        [HttpPost("InsertOne")]
        public async Task<string> InsertOne([FromForm] string entity)
        {
            string result = await _serviceFactory.Service.InsertOneEntity(entity);

            return result;
        }

        [HttpPost("InsertMany")]
        public async Task<string> InsertMany([FromForm] string entities)
        {
            string result = await _serviceFactory.Service.InsertManyEntity(entities);

            return result;
        }
        [HttpPost("UpdateMany")]
        public string UpdateMany([FromForm] string entities)
        {
            string result = _serviceFactory.Service.UpdateManyEntity(entities);

            return result;
        }
        [HttpPost("UpdateOne")]
        public async Task<string> UpdateOne([FromForm] string entity)
        {
            string result = await _serviceFactory.Service.UpdateOneEntity(entity);

            return result;
        }

    }
}
