using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Settings;

namespace WebApi.Factory
{
    class RepositoryFactory<T,S> : IRepositoryFactory<T,S> where T : IEntityBase where S : IRepository<T>
    {
        public S Repository { get; set; }
        
        public RepositoryFactory(IOptions<MongoSettings> settings)
        {          
            Repository = (S)Activator.CreateInstance(typeof(S), settings);
        }


    }
}
