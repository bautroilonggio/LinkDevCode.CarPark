using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public interface ITicketRepository : IRepositoryBase<Ticket>
    {
        Task<(IEnumerable<Ticket>, PaginationMetadata)> GetAllAsync(
            string? customerName, string? searchQuery, int pageNumber, int pageSize);
    }
}