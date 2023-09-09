﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JwtUser.Core.Entities
{
    public class PackageHelper : BaseEntity
    {
        public string Name { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Transport> Transports { get; set; }
    }
}
