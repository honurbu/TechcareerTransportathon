using AutoMapper;
using JwtUser.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;
        public ApplicationController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetApplications()
        {
            return Ok(_applicationService.GetAllAsync());
        }    
        
        [HttpGet]
        [Route("GetRelations")]
        public IActionResult GetApplicationsWithRelations()
        {
            return Ok(_applicationService.GetApplicationswithRelations());
        }
    }
}
