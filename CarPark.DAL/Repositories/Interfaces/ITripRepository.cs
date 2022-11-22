using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public interface ITripRepository : IRepositoryBase<Trip>
    {
        Task<(IEnumerable<Trip>, PaginationMetadata)> GetAllAsync(
            string? destination, string? searchQuery, int pageNumber, int pageSize);
    }
}