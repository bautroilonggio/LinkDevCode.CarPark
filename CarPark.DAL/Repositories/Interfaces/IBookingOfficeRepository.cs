using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories.Interfaces
{
    public interface IBookingOfficeRepository : IRepositoryBase<BookingOffice>
    {
        void Add(Trip trip, BookingOffice bookingOffice);
        void Delete(Trip trip, BookingOffice bookingOffice);
        Task<(IEnumerable<BookingOffice>, PaginationMetadata)> GetAllAsync(
            string? officeName, string? searchQuery, int pageNumber, int pageSize);
    }
}