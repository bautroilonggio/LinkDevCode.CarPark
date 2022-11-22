using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        //Task<IEnumerable<Car>> GetCarsAsync();
        Task<(IEnumerable<Car>, PaginationMetadata)> GetAllAsync(
            string? licensePlate, string? searchQuery, int pageNumber, int pageSize);
    }
}