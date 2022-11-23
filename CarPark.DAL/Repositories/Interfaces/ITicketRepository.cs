using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public interface ITicketRepository : IRepositoryBase<Ticket>
    {
        void Add(Car car, Trip trip, Ticket ticket);
        void Delete(Trip trip, Ticket ticket);
        Task<(IEnumerable<Ticket>, PaginationMetadata)> GetAllAsync(
            string? customerName, string? searchQuery, int pageNumber, int pageSize);
    }
}