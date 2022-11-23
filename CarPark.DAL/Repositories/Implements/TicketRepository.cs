using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarPark.DAL.Repositories
{
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        private readonly CarParkContext _context;

        public TicketRepository(CarParkContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets
                         .Include(ticket => ticket.Trip)
                         .Include(ticket => ticket.Car)
                         .ToListAsync();
        }

        public override async Task<Ticket?> GetSingleAsync(object ticketId)
        {
            return await _context.Tickets
                         .Include(ticket => ticket.Trip)
                         .Include(ticket => ticket.Car)
                         .Where(ticket => ticket.TicketId == (int)ticketId)
                         .FirstOrDefaultAsync();
        }

        public void Add(Car car, Trip trip, Ticket ticket)
        {
            car.Tickets.Add(ticket);
            trip.Tickets.Add(ticket);
            trip.BookedTicketNumber = trip.Tickets.Count;
        }

        public void Delete(Car car, Trip trip, Ticket ticket)
        {
            Delete(ticket);
            car.Tickets.Remove(ticket);
            trip.Tickets.Remove(ticket);
            trip.BookedTicketNumber = trip.Tickets.Count;
        }

        public async Task<(IEnumerable<Ticket>, PaginationMetadata)> GetAllAsync(
            string? customerName, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Tickets.Include(t => t.Trip).Include(t => t.Car) as IQueryable<Ticket>;

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                customerName = customerName.Trim();
                collection = collection.Where(b => b.CustomerName == customerName);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(t => t.CustomerName.Contains(searchQuery)
                                           || (t.Trip.Destination != null && t.Trip.Destination.Contains(searchQuery))
                                           || (t.Car.LicensePlate != null && t.Car.LicensePlate.Contains(searchQuery)));
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