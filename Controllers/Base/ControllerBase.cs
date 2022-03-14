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
    [Route("[controller]")]
    [ApiController]
    public class ControllerBase<T,S> : Controller where T:IEntityBase, new() where S : IServiceBase<T>, new()
    {
        public ServiceFactory<T, S> ServiceFactory { get; set;  }
        public IServiceBase<T> Service { get; set; }

        public ControllerBase() {
            Service = ServiceFactory.CreateInstance();
        }

        [HttpGet]
        public virtual async Task<string> GetAll()
        {
            string result = await Service.GetAllEntity();

            return result;
        }


    }
}
