using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarPark.API.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService ?? throw new ArgumentNullException(nameof(ticketService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsAsync(
            string? customerName, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var (tickets, paginationMetadata) = await _ticketService.GetTicketsAsync(
                                                     customerName, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            if (tickets.Count() == 0)
            {
                return NotFound();
            }

            return Ok(tickets);
        }

        [HttpGet("{ticketId}", Name = "GetTicket")]
        public async Task<ActionResult<TicketDto>> GetTicketAsync(int ticketId)
        {
            var ticket = await _ticketService.GetTicketAsync(ticketId);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<TicketDto>> CreateTicketAsync(
            string licensePlate, string destination, TicketFroCreateDto ticket)
        {
            var createTicketToReturn = await _ticketService
                                            .CreateTicketAsync(licensePlate, destination, ticket);

            if (createTicketToReturn == null)
            {
                return NotFound();
            }
            return CreatedAtRoute("GetTicket",
                new { ticketId = createTicketToReturn.TicketId },
                createTicketToReturn);
        }

        [HttpDelete("{ticketId}")]
        public async Task<ActionResult> DeleteTicketAsync(string licensePlate, 
            string destination, int ticketId)
        {
            if (!await _ticketService.DeleteTicketAsync(licensePlate, destination, ticketId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}