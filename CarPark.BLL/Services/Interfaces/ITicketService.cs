using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketDto>> GetTicketsAsync();

        Task<TicketDto> CreateTicketAsync(TicketFroCreateDto ticket);

        Task<TicketDto?> GetTicketAsync(int ticketId);

        Task<bool> DeleteTicketAsync(int ticketId);
    }
}