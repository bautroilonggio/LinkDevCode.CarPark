using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.API.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService ?? throw new ArgumentNullException(nameof(carService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCarsAsync()
        {
            return Ok(await _carService.GetCarsAsync());
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
        public async Task<ActionResult<CarDto>> CreateCarAsync(CarFroCreateDto car)
        {
            var createCarToReturn = await _carService.CreateCarAsync(car);

            if (createCarToReturn == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetCar",
                new { licensePlate = createCarToReturn.LicensePlate },
                createCarToReturn);
        }

        [HttpPut("{licensePlate}")]
        public async Task<ActionResult> UpdateCarAsync(string licensePlate, CarForUpdateDto car)
        {
            if (!await _carService.UpdateCarAsync(licensePlate, car))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{licensePlate}")]
        public async Task<ActionResult> DeleteCarAsync(string licensePlate)
        {
            if (!await _carService.DeleteCarAsync(licensePlate))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}