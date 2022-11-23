using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<Car?> GetCarIncludeTickets(Expression<Func<Car, bool>> where)
        {
            return await _context.Cars
                        .Include(car => car.Tickets)
                        .Where(where)
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

        public void Add(ParkingLot parkingLot, Car car)
        {
            parkingLot.Cars.Add(car);

            if (parkingLot.Cars.Count == 1)
            {
                parkingLot.ParkStatus = "1 car";
            }
            else
            {
                parkingLot.ParkStatus = $"{parkingLot.Cars.Count} cars";
            }
        }

        public void Delete(ParkingLot parkingLot, Car car)
        {
            Delete(car);
            parkingLot.Cars.Remove(car);

            if(parkingLot.Cars.Count == 0)
            {
                parkingLot.ParkStatus = "Empty";
            }
            else if(parkingLot.Cars.Count == 1)
            {
                parkingLot.ParkStatus = "1 car";
            }
            else
            {
                parkingLot.ParkStatus = $"{parkingLot.Cars.Count} cars";
            }
        }

        public async Task<(IEnumerable<Car>, PaginationMetadata)> GetAllAsync(
            string? licensePlate, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Cars.Include(c => c.ParkingLot) as IQueryable<Car>;

            if (!string.IsNullOrWhiteSpace(licensePlate))
            {
                licensePlate = licensePlate.Trim();
                collection = collection.Where(c => c.LicensePlate == licensePlate);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(c => c.LicensePlate.Contains(searchQuery)
                                           || (c.CarType != null && c.CarType.Contains(searchQuery))
                                           || (c.CarColor != null && c.CarColor.Contains(searchQuery))
                                           || (c.Company != null && c.Company.Contains(searchQuery))
                                           || (c.ParkingLot.ParkName != null && c.ParkingLot.ParkName.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await collection.Skip(pageSize * (pageNumber - 1))
                                                     .Take(pageSize)
                                                     .ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }
    }
}