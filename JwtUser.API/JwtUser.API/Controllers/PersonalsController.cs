using AutoMapper;
using JwtUser.Core.DTOs.Response;
using JwtUser.Core.Entities;
using JwtUser.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonalService _personalService;
        public PersonalsController(IMapper mapper, IPersonalService personalService)
        {
            _mapper = mapper;
            _personalService = personalService;
        }

        [HttpGet]
        public IActionResult GetPersonal()
        {
            var result = _personalService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersonal([FromBody]PersonalDto personalDto)
        {
            var personal = _mapper.Map<Personal>(personalDto);

            await _personalService.AddAsync(personal);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdatePersonal(PersonalDto personalDto)
        {
            var updatePersonal = _mapper.Map<Personal>(personalDto);

            _personalService.Update(updatePersonal);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePersonal(int id)
        {
            var hasPpersonal = await _personalService.GetByIdAsync(id);

             _personalService.Remove(hasPpersonal);

            return Ok();
        }
    }
}
