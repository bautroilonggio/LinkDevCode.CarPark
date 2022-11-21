using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface IBookingOfficeService
    {
        Task<IEnumerable<BookingOfficeDto>> GetBookingOfficesAsync();
        Task<BookingOfficeDetailDto?> GetBookingOfficeAsync(int officeId);
        Task<BookingOfficeDetailDto> CreateBookingOfficeAsync(BookingOfficeForCreateDto bookingOffice);
        Task<bool> DeleteBookingOfficeAsync(int officeId);
    }
}