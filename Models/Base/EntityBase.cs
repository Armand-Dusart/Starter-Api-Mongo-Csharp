using WebApi.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WepApi.Models
{
    public abstract class EntityBase : IEntityBase
    {
        public ObjectId Id { get; set; }
        public DateTime CreatDate => Id.CreationTime;
        public DateTime ModifDate { get; set; } 
    }
}
