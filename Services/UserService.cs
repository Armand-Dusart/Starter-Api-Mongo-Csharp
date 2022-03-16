using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Factory;
using WebApi.Interfaces;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services
{
    public class UserService : ServiceBase<UserModel>
    {
        public UserService(IRepositoryFactory<UserModel,Repository<UserModel>> repositoryFactory) : base(repositoryFactory)
        {

        }

        public string Yolo()
        {
            return "Yolo";
        }
    }
}
