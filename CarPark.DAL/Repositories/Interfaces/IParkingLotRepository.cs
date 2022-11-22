using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public interface IParkingLotRepository : IRepositoryBase<ParkingLot>
    {
        Task<(IEnumerable<ParkingLot>, PaginationMetadata)> GetAllAsync(
            string? parkName, string? searchQuery, int pageNumber, int pageSize);
    }
}