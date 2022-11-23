using CarPark.DAL.Entities;
using System.Linq.Expressions;

namespace CarPark.DAL.Repositories
{
    public interface IParkingLotRepository : IRepositoryBase<ParkingLot>
    {
        Task<ParkingLot?> GetParkingLotIncludeCars(Expression<Func<ParkingLot, bool>> where);
        Task<(IEnumerable<ParkingLot>, PaginationMetadata)> GetAllAsync(
            string? parkName, string? searchQuery, int pageNumber, int pageSize);
    }
}