using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsAsync()
        {
            return Ok(await _ticketService.GetTicketsAsync());
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
        public async Task<ActionResult<TicketDto>> CreateTicketAsync(TicketFroCreateDto ticket)
        {
            var createTicketToReturn = await _ticketService.CreateTicketAsync(ticket);

            if (createTicketToReturn == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetTicket",
                new { ticketId = createTicketToReturn.TicketId },
                createTicketToReturn);
        }

        [HttpDelete("{ticketId}")]
        public async Task<ActionResult> DeleteTicketAsync(int ticketId)
        {
            if (!await _ticketService.DeleteTicketAsync(ticketId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
