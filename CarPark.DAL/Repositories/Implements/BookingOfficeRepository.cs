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
    }
}