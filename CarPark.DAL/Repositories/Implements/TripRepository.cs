using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarPark.DAL.Repositories
{
    public class TripRepository : RepositoryBase<Trip>, ITripRepository
    {
        private readonly CarParkContext _context;

        public TripRepository(CarParkContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Trip?> GetTripIncludeBookingOffices(Expression<Func<Trip, bool>> where)
        {
            return await _context.Trips.Include(t => t.BookingOffices)
                                       .Where(where)
                                       .FirstOrDefaultAsync();
        }

        public async Task<Trip?> GetTripIncludeTickets(Expression<Func<Trip, bool>> where)
        {
            return await _context.Trips.Include(t => t.Tickets)
                                       .Where(where)
                                       .FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<Trip>, PaginationMetadata)> GetAllAsync(
            string? destination, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Trips as IQueryable<Trip>;

            if (!string.IsNullOrWhiteSpace(destination))
            {
                destination = destination.Trim();
                collection = collection.Where(t => t.Destination == destination);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(t => t.Destination.Contains(searchQuery)
                                           || (t.CarType != null && t.CarType.Contains(searchQuery))
                                           || (t.Driver != null && t.Driver.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var colectionToReturn = await collection.Skip(pageSize * (pageNumber - 1))
                                                    .Take(pageSize)
                                                    .ToListAsync();

            return (colectionToReturn, paginationMetadata);
        }
    }
}