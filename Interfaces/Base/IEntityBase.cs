using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IEntityBase
    {
        ObjectId Id { get; set; }
        DateTime CreatDate { get; set; }
        DateTime ModifDate { get; set; }
    }
}
