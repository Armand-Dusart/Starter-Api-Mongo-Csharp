using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Attributes;
using WepApi.Models;

namespace WebApi.Models
{
    [BsonCollection("Company")]
    public class CompanyModel : EntityBase
    {
        public string CompanyName { get; set; }
    }
}
