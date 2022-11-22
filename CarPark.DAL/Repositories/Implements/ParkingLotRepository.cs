using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public class ParkingLotRepository : RepositoryBase<ParkingLot>, IParkingLotRepository
    {
        public ParkingLotRepository(CarParkContext context) : base(context)
        {
        }
    }
}