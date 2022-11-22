using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        //Task<IEnumerable<Car>> GetCarsAsync();
    }
}