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

        [HttpGet]
        public virtual async Task<string> GetAll()
        {
            string result = await _serviceFactory.Service.GetAllEntity();

            return result;
        }

    }
}
