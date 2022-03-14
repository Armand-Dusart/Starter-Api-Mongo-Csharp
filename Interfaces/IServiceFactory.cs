using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IServiceFactory<T> where T: IEntityBase
    {
        public void CreateInstance();
    }
}
