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

        
    }
}

