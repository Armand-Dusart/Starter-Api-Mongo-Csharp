﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Interfaces
{
    public interface ISettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
