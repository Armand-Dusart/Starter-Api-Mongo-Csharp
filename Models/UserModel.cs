using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Attributes;
using WepApi.Models;

namespace WebApi.Models
{
    [BsonCollection("User")]
    public class UserModel : EntityBase
    {
        public string FirstName { get; set;  }
        public string LastName { get; set; }
        public ObjectId CompanyID { get; set; }
    }
}
