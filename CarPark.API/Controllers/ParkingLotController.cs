using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.API.Controllers
{
    [Route("api/parkinglots")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;

        public ParkingLotController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService ??
                throw new ArgumentNullException(nameof(parkingLotService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingLotDto>>> GetParkingLotsAsync(bool onlyEmptyStatus = false)
        {
            if(onlyEmptyStatus)
            {
                return Ok(await _parkingLotService.GetParkingLotsEmptyAsync()); 
            }

            return Ok(await _parkingLotService.GetParkingLotsAsync());
        }

        [HttpGet("{parkingLotId}", Name = "GetParkingLotById")]
        public async Task<ActionResult<ParkingLotDto>> GetParkingLotAsync(int parkingLotId)
        {
            var parkingLot = await _parkingLotService.GetParkingLotAsync(parkingLotId);

            if (parkingLot == null)
            {
                return NotFound();
            }

            return Ok(parkingLot);
        }

        [HttpPost]
        public async Task<ActionResult<ParkingLotDto>> CreateParkingLotAsync(ParkingLotForCreateDto parkingLot)
        {
            var createParkingLotToReturn = await _parkingLotService.CreateParkingLotAsync(parkingLot);

            if (createParkingLotToReturn == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute(
                    "GetParkingLotById",
                    new
                    {
                        parkingLotId = createParkingLotToReturn.ParkId
                    },
                    createParkingLotToReturn);
        }

        [HttpPut("{parkingLotId}")]
        public async Task<ActionResult> UpdateParkingLotAsync(int parkingLotId, ParkingLotForUpdateDto parkingLot)
        {
            if (!await _parkingLotService.UpdateParkingLotAsync(parkingLotId, parkingLot))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{parkingLotId}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int parkingLotId)
        {
            if (!await _parkingLotService.DeleteParkingLotAsync(parkingLotId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
