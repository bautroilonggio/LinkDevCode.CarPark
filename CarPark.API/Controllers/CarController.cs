using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarPark.API.Controllers
{
    [Route("api/cars")]
    [Authorize]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsAsync(
            string? licensePlate, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var (cars, paginationMetadata) = await _carService.GetCarsAsync(
                                                     licensePlate, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            if (cars.Count() == 0)
            {
                return NotFound();
            }

            return Ok(cars);
        }

        [HttpGet("{licensePlate}", Name = "GetCar")]
        public async Task<ActionResult<CarDto>> GetCarAsync(string licensePlate)
        {
            var car = await _carService.GetCarAsync(licensePlate);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<CarDto>> CreateCarAsync(string parkName, CarFroCreateDto car)
        {
            var createCarToReturn = await _carService.CreateCarAsync(parkName, car);

            if (createCarToReturn == null)
            {
                return NotFound();
            }
            return CreatedAtRoute("GetCar",
                new { licensePlate = createCarToReturn.LicensePlate },
                createCarToReturn);
        }

        [HttpPut("{licensePlate}")]
        public async Task<ActionResult> UpdateCarAsync(string parkName, string licensePlate, CarForUpdateDto car)
        {
            if (!await _carService.UpdateCarAsync(parkName, licensePlate, car))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{licensePlate}")]
        public async Task<ActionResult> DeleteCarAsync(string parkName, string licensePlate)
        {
            if (!await _carService.DeleteCarAsync(parkName, licensePlate))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}