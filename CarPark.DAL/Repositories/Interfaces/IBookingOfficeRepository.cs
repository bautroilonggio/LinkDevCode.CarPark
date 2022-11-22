using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories.Interfaces
{
    public interface IBookingOfficeRepository : IRepositoryBase<BookingOffice>
    {
        Task<(IEnumerable<BookingOffice>, PaginationMetadata)> GetAllAsync(
            string? officeName, string? searchQuery, int pageNumber, int pageSize);
    }
}