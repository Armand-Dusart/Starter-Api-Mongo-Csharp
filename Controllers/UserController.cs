using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Factory;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Services;
using WebApi.Settings;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase<UserModel, UserService>
    {
        public UserController(IServiceFactory<UserModel, UserService> serviceFactory) : base(serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        [HttpGet("GetAll")]
        public async Task<string> GetAll()
        {
            string result = await _serviceFactory.Service.GetAllEntity();

            return result;
        }

        [HttpGet("test")]
        public string test()
        {

            string result = _serviceFactory.Service.Yolo();

            return result;
        }


    }
}

