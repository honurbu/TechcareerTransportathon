﻿using JwtUser.Core.DTOs.Response;
using JwtUser.Core.Entities;
using JwtUser.Core.Repositories;
using JwtUser.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtUser.Repository.Repositories
{
    public class ApplicationRepository : GenericRepository<Application>, IApplicationRepository
    {
        public ApplicationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public decimal AverageRate(string id)
        {
            var count = _dbContext.Applications.Where(x => x.IsSuccess == true && x.Rate != null && x.CompanyId == id).Count();
            var rate = (decimal)_dbContext.Applications.Where(x => x.IsSuccess == true && x.Rate != null && x.CompanyId == id).Sum(x => x.Rate) / count;
            return rate;
        }

        public async Task<Dictionary<string, object>> GetApplicationsWithRATE(int id)
        {
            var values = await _dbContext.Applications
                    .Where(x => x.TransportId == id)
                    .Include(x => x.Company)
                    .Include(x => x.Cars)
                    .Include(x => x.AppPersonels)
                        .ThenInclude(x => x.Personals)
                            .ThenInclude(x => x.Appellation)
                    .ToListAsync();

            string compId = _dbContext.Applications
                .Where(x => x.TransportId == id)
                .Select(x => x.CompanyId)
                .FirstOrDefault();

            var result = new Dictionary<string, object>
            {
                 { "values", values },
                 { "rate", CalculateRate(compId) } 
            };

            return result;
        }

        private decimal CalculateRate(string companyId)
        {
            var count = _dbContext.Applications
                .Where(x => x.IsSuccess == true && x.Rate != null && x.CompanyId == companyId)
                .Count();

            var rateSum = _dbContext.Applications
                .Where(x => x.IsSuccess == true && x.Rate != null && x.CompanyId == companyId)
                .Sum(x => x.Rate);

            var rate = Math.Floor((decimal)(rateSum / count * 10)!) / 10; 

            return rate;
        }



        public int GetTransportApplicationCount(int id)
        {
            return _dbContext.Applications.Where(x => x.TransportId == id).Count();
        }

        public decimal Updaterating(int id, int rate)
        {
            var application = _dbContext.Applications.FirstOrDefault(x => x.Id == id);

            application!.Rate = rate; 
            _dbContext.SaveChanges(); 
            return (decimal)application.Rate;

        }

        public void ConfirmTransport(int id)
        {
            var application = _dbContext.Applications.FirstOrDefault(x => x.Id == id);
            application!.IsSuccess = true;
            _dbContext.SaveChanges();
        }
    }
}
