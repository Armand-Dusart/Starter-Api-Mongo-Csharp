using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IRepositoryFactory<T, S> where T : IEntityBase where S : IRepository<T>
    {
        public S Repository { get; set; }
    }
}
