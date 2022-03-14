using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    public class ControllerBase<T,S> : ControllerBase where T:IEntityBase where S : IServiceBase<T>
    {

    }
}
