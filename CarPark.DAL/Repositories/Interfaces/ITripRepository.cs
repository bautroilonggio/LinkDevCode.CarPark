using CarPark.DAL.Entities;
using System.Linq.Expressions;

namespace CarPark.DAL.Repositories
{
    public interface ITripRepository : IRepositoryBase<Trip>
    {
        Task<Trip?> GetTripIncludeBookingOffices(Expression<Func<Trip, bool>> where);
        Task<Trip?> GetTripIncludeTickets(Expression<Func<Trip, bool>> where);
        Task<(IEnumerable<Trip>, PaginationMetadata)> GetAllAsync(
            string? destination, string? searchQuery, int pageNumber, int pageSize);
    }
}