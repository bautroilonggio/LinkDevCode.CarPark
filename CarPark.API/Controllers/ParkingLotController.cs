using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public async Task<ActionResult<IEnumerable<ParkingLotDto>>> GetParkingLotsAsync(
             string? parkName, string? searchQuery, bool onlyEmptyStatus = false, int pageNumber = 1, int pageSize = 10)
        {
            if (onlyEmptyStatus)
            {
                var parkingLotsEmpty = await _parkingLotService.GetParkingLotsEmptyAsync();

                if(parkingLotsEmpty == null)
                {
                    return NotFound();
                }    

                return Ok(parkingLotsEmpty);
            }

            var (parkingLots, paginationMetadata) = await _parkingLotService.GetParkingLotsAsync(
                                                          parkName, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            if(parkingLots.Count() == 0)
            {
                return NotFound();
            }

            return Ok(parkingLots);
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