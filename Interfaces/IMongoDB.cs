using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface IMongoDB
    {
        public IMongoCollection<T> GetCollection<T>(string name);
    }
}
