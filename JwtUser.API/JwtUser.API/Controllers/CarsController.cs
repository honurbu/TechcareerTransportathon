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
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;
        private readonly IMapper _mapper;
        public CarsController(ICarsService carsService, IMapper mapper)
        {
            _carsService = carsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_carsService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCars(CarsDto carsDto)
        {
            var cars = _mapper.Map<Cars>(carsDto);

            await _carsService.AddAsync(cars);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCars(int id)
        {
            var hasCars = await _carsService.GetByIdAsync(id);

            if (hasCars == null)
                return NoContent();

            _carsService.Remove(hasCars);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCars(CarsDto carsDto)
        {
            var updateCars = _mapper.Map<Cars>(carsDto);

            _carsService.Update(updateCars);

            return Ok();
        }
    }
}
