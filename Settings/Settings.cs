using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;

namespace WebApi.Settings
{
    public class Settings : ISettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
