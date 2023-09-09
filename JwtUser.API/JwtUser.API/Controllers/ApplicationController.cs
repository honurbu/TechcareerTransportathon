using AutoMapper;
using JwtUser.Core.DTOs.Request;
using JwtUser.Core.Entities;
using JwtUser.Core.Services;
using JwtUser.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public ApplicationController(IApplicationService applicationService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _applicationService = applicationService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IActionResult GetApplications()
        {
            return Ok(_applicationService.GetAllAsync());
        }    
        
        [HttpGet()]
        [Route("GetRelations")]
        public async  Task<IActionResult> GetApplicationsWithRelations(int id)
        {
            return Ok(await _applicationService.GetApplicationswithRelations(id));
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddApplication(AddApplicationDto addApplicationDto)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var transport = _mapper.Map<Application>(addApplicationDto);

            transport.CompanyId = userId;

            await _applicationService.AddAsync(transport);
            return Ok("Data success add");
        }
    }
}
