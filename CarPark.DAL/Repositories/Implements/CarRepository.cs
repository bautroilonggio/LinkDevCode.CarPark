using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPark.DAL.Repositories
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        private readonly CarParkContext _context;
        public CarRepository(CarParkContext context) : base(context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public override async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars
                        .Include(car => car.ParkingLot)
                        .ToListAsync();
        }

        public override async Task<Car?> GetSingleAsync(object licensePlate)
        {
            return await _context.Cars
                        .Include(car => car.ParkingLot)
                        .Where(car => car.LicensePlate == (string)licensePlate)
                        .FirstOrDefaultAsync();
        }

        //public async Task<IEnumerable<CarDto>?> GetCarsAsync()
        //{
        //    return await (from car in _context.Cars
        //                  join park in _context.ParkingLots
        //                  on car.ParkId equals park.ParkId
        //                  select new CarDto
        //                  {
        //                      LicensePlate = car.LicensePlate,
        //                      CarType = car.CarType,
        //                      CarColor = car.CarColor,
        //                      Company = car.Company,
        //                      ParkName = park.ParkName
        //                  }).ToListAsync();
        //}
    }
}
