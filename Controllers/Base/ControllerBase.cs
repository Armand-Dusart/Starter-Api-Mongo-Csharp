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
    [ApiController]
    [Route("[controller]")]
    public class ControllerBase<T,S> : Controller where T:IEntityBase where S : IServiceBase<T>, new()
    {
        public readonly ServiceFactory<T, S> ServiceFactory;

        public ControllerBase(ServiceFactory<T, S> serviceFactory) {
            ServiceFactory = serviceFactory;
            ServiceFactory.CreateInstance();
        }

        [HttpGet]
        public virtual async Task<string> GetAll()
        {
            string result = await ServiceFactory.Service.GetAllEntity();

            return result;
        }



    }
}
