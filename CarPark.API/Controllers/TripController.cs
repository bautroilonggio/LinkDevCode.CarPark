using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarPark.API.Controllers
{
    [Route("api/trips")]
    [Authorize]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService ??
                throw new ArgumentNullException(nameof(tripService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDto>>> GetTripsAsync(
            string? destination, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var (trips, paginationMetadata) = await _tripService
                .GetTripsAsync(destination, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            if (trips.Count() == 0)
            {
                return NotFound();
            }

            return Ok(trips);
        }

        [HttpGet("{tripId}", Name = "GetTripById")]
        public async Task<ActionResult<TripDto>> GetTripAsync(int tripId)
        {
            var trip = await _tripService.GetTripAsync(tripId);

            if (trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }

        [HttpPost]
        public async Task<ActionResult<TripDto>> CreateTripAsync(TripForCreateDto trip)
        {
            var createTripToReturn = await _tripService.CreateTripAsync(trip);

            if (createTripToReturn == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute(
                    "GetTripById",
                    new
                    {
                        tripId = createTripToReturn.TripId
                    },
                    createTripToReturn);
        }

        [HttpPut("{tripId}")]
        public async Task<ActionResult> UpdateTripAsync(int tripId, TripForUpdateDto trip)
        {
            if (!await _tripService.UpdateTripAsync(tripId, trip))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{tripId}")]
        public async Task<ActionResult> DeleteTripAsync(int tripId)
        {
            if (!await _tripService.DeleteTripAsync(tripId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}