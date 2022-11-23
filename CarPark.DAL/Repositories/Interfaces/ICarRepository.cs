using CarPark.DAL.Entities;
using System.Linq.Expressions;

namespace CarPark.DAL.Repositories
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        //Task<IEnumerable<Car>> GetCarsAsync();
        Task<(IEnumerable<Car>, PaginationMetadata)> GetAllAsync(
            string? licensePlate, string? searchQuery, int pageNumber, int pageSize);

        Task<Car?> GetCarIncludeTickets(Expression<Func<Car, bool>> where);

        void Add(ParkingLot parkingLot, Car car);

        void Delete(ParkingLot parkingLot, Car car);
    }
}