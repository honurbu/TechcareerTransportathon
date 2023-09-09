﻿using JwtUser.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtUser.Core.DTOs.Response
{
    public class AdvertsDto
    {
        public AppUser? CompanyId { get; set; }
        public Transport? TransportId { get; set; }
        public Personal? PersonalId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Date { get; set; }
    }
}
