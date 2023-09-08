using JwtUser.Core.Entities;
using JwtUser.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportService;

        public TransportController(ITransportService transportService)
        {
            _transportService = transportService;
        }


        [HttpGet]
        public IActionResult GetListTransports()
        {
            var values =  _transportService.GetAllAsync();            
            return Ok(values);            
        }
    }
}
