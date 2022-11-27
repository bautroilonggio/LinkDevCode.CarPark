using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using CarPark.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarPark.DAL.Repositories
{
    public class BookingOfficeRepository : RepositoryBase<BookingOffice>, IBookingOfficeRepository
    {
        private readonly CarParkContext _context;

        public BookingOfficeRepository(CarParkContext context)
            : base(context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public override async Task<IEnumerable<BookingOffice>> GetAllAsync()
        {
            return await _context.BookingOffices
                         .Include(bookingOffice => bookingOffice.Trip)
                         .ToListAsync();
        }

        public override async Task<BookingOffice?> GetSingleAsync(object officeId)
        {
            return await _context.BookingOffices
                         .Include(bookingOffice => bookingOffice.Trip)
                         .Where(bookingOffice => bookingOffice.OfficeId == (int)officeId)
                         .FirstOrDefaultAsync();
        }

        public void Add(Trip trip, BookingOffice bookingOffice)
        {
            trip.BookingOffices.Add(bookingOffice);
        }

        public void Delete(Trip trip, BookingOffice bookingOffice)
        {
            Delete(bookingOffice);
            trip.BookingOffices.Remove(bookingOffice);
        }

        public async Task<(IEnumerable<BookingOffice>, PaginationMetadata)> GetAllAsync(
            string? officeName, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.BookingOffices.Include(b => b.Trip) as IQueryable<BookingOffice>;

            if(!string.IsNullOrWhiteSpace(officeName))
            {
                officeName = officeName.Trim();
                collection = collection.Where(b => b.OfficeName == officeName);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(b => b.OfficeName.Contains(searchQuery)
                                           || (b.Trip.Destination != null && b.Trip.Destination.Contains(searchQuery)));
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