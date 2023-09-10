﻿using JwtUser.Core.Entities;
using JwtUser.Core.Repositories;
using JwtUser.Core.Services;
using JwtUser.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtUser.Service.Services
{
    public class ApplicationService : GenericService<Application>, IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IGenericRepository<Application> genericRepository, IUnitOfWork unitOfWork, IApplicationRepository applicationRepository) : base(genericRepository, unitOfWork)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<List<Application>> GetApplicationswithRelations(int id)
        {
            return await _applicationRepository.GetApplicationswithRelations(id);
        }

        public int GetTransportApplicationCount(int id)
        {
            return _applicationRepository.GetTransportApplicationCount(id);
        }
    }
}
