using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarPark.API.Controllers
{
    [Route("api/bookingoffices")]
    [ApiController]
    public class BookingOfficeController : ControllerBase
    {
        private readonly IBookingOfficeService _bookingOfficeService;

        public BookingOfficeController(IBookingOfficeService bookingOfficeService)
        {
            _bookingOfficeService = bookingOfficeService ??
                throw new ArgumentNullException(nameof(bookingOfficeService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingOfficeDto>>> GetBookingOfficesAsync(
            string? officeName, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var (bookingOffices, paginationMetadata) = await _bookingOfficeService.GetBookingOfficesAsync(
                                                     officeName, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            if(bookingOffices.Count() == 0)
            {
                return NotFound();
            }

            return Ok(bookingOffices);
        }

        [HttpGet("{officeId}", Name = "GetBookingOffice")]
        public async Task<ActionResult<BookingOfficeDetailDto>> GetBookingOfficeAsync(int officeId)
        {
            var bookingOffice = await _bookingOfficeService.GetBookingOfficeAsync(officeId);

            if (bookingOffice == null)
            {
                return NotFound();
            }

            return Ok(bookingOffice);
        }

        [HttpPost]
        public async Task<ActionResult<BookingOfficeDetailDto>> CreateBookingOfficetAsync(
            BookingOfficeForCreateDto bookingOffice)
        {
            var createBookingOfficeToReturn = await _bookingOfficeService.CreateBookingOfficeAsync(bookingOffice);

            if (createBookingOfficeToReturn == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetBookingOffice",
                new { officeId = createBookingOfficeToReturn.OfficeId },
                createBookingOfficeToReturn);
        }

        [HttpDelete("{officeId}")]
        public async Task<ActionResult> DeleteBookingOfficeAsync(int officeId)
        {
            if (!await _bookingOfficeService.DeleteBookingOfficeAsync(officeId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}