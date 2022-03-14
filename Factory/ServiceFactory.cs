using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Repository;

namespace WebApi.Factory
{
    public class ServiceFactory<T,S> : IServiceFactory<T> where T : IEntityBase where S : IServiceBase<T>
    {
        public IServiceBase<T> Service;

        public void CreateInstance()
        {
            Service = (IServiceBase<T>)Activator.CreateInstance(typeof(S));
        }

    }
}
