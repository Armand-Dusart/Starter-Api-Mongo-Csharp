using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Factory;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase<UserModel, UserService>
    {
        public UserController() : base(new ServiceFactory<UserModel, UserService>())
        {

        }

        [HttpGet("GetAll")]
        public async Task<string> GetAll()
        {
            string result = await ServiceFactory.Service.GetAllEntity();

            return result;
        }

        [HttpGet("test")]
        public string test()
        {
            string result = "test";

            return result;
        }


    }
}

