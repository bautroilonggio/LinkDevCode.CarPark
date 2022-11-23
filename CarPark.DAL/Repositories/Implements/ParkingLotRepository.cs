using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace CarPark.DAL.Repositories
{
    public class ParkingLotRepository : RepositoryBase<ParkingLot>, IParkingLotRepository
    {
        private readonly CarParkContext _context;

        public ParkingLotRepository(CarParkContext context) : base(context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<ParkingLot?> GetParkingLotIncludeCars(Expression<Func<ParkingLot, bool>> where)
        {
            return await _context.ParkingLots
                        .Include(p => p.Cars)
                        .Where(where)
                        .FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<ParkingLot>, PaginationMetadata)> GetAllAsync(
            string? parkName, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.ParkingLots as IQueryable<ParkingLot>;

            if (!string.IsNullOrWhiteSpace(parkName))
            {
                parkName = parkName.Trim();
                collection = collection.Where(p => p.ParkName == parkName);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(p => p.ParkName.Contains(searchQuery)
                                           || (p.ParkArea != null && p.ParkArea.Contains(searchQuery))
                                           || (p.ParkPlace != null && p.ParkPlace.Contains(searchQuery))
                                           || (p.ParkStatus != null && p.ParkStatus.Contains(searchQuery)));
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