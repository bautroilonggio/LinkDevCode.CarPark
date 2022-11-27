using CarPark.DAL;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface ITicketService
    {
        Task<(IEnumerable<TicketDto>, PaginationMetadata)> GetTicketsAsync(
            string? customername, string? searchQuery, int pageNumber, int pageSize);

        Task<TicketDto?> CreateTicketAsync(string licensePlate, 
            string destination, TicketForCreateDto ticket);

        Task<TicketDto?> GetTicketAsync(int ticketId);

        Task<bool> UpdateTicketAsync(
            string licensePlate, string destination,
            int ticketId, TicketForUpdateDto ticket);

        Task<bool> DeleteTicketAsync(string licensePlate, string destination, int ticketId);
    }
}