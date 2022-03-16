using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Repository;
using WebApi.Settings;

namespace WebApi.Factory
{
    public class ServiceFactory<T,S> : IServiceFactory<T,S> where T : IEntityBase where S : IServiceBase<T>
    {
        public S Service { get; set; }

        public ServiceFactory(IRepositoryFactory<T, Repository<T>> repositoryFactory)
        {
            Service = (S)Activator.CreateInstance(typeof(S), repositoryFactory);
        }

    }
}
