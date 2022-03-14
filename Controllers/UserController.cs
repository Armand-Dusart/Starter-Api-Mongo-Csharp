using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase<UserModel, ServiceBase<UserModel>>
    {
        public UserController() : base()
        {

        }

        [HttpGet("GetAll")]
        public override async Task<string> GetAll()
        {
            Console.WriteLine("test");
            string result = await ServiceFactory.Service.GetAllEntity();

            return result;
        }
    }
}

