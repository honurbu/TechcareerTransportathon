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

        public async Task<List<Application>> GetApplicationswithRelations(int id)
        {
            return await _dbContext.Applications
                .Where(x=>x.TransportId==id)
                .Include(x=>x.Transports)
                    .ThenInclude(x=>x.Category)
                .Include(x=>x.Transports)
                    .ThenInclude(x=>x.Insurances)
                .Include(x=>x.Transports)
                    .ThenInclude(x=>x.PackageHelpers)
                .Include(x=>x.Transports)
                    .ThenInclude(x=>x.Street)
                .Include(x=>x.Transports)
                    .ThenInclude(x=>x.HowCarries)
                .Include(x=>x.Company)
                .ToListAsync();
        }
    }
}
