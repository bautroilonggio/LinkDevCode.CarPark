using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public class TripRepository : RepositoryBase<Trip>, ITripRepository
    {
        public TripRepository(CarParkContext context) : base(context)
        {
        }
    }
}