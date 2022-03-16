using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IServiceFactory<T,S> where T: IEntityBase where S : IServiceBase<T>
    {
        public S Service { get; set; }
    }
}
