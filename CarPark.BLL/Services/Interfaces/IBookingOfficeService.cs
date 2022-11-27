using CarPark.DAL;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface IBookingOfficeService
    {
        Task<(IEnumerable<BookingOfficeDto>, PaginationMetadata)> GetBookingOfficesAsync(
            string? officeName, string? searchQuery, int pageNumber, int pageSize);

        Task<BookingOfficeDetailDto?> GetBookingOfficeAsync(int officeId);

        Task<BookingOfficeDetailDto?> CreateBookingOfficeAsync(
            string destination, BookingOfficeForCreateDto bookingOffice);
        Task<bool> UpdateBookingOfficeAsync(
            string destination, int officeId,
            BookingOfficeForUpdateDto bookingOffice);

        Task<bool> DeleteBookingOfficeAsync(string destination, int officeId);
    }
}