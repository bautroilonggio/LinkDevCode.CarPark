using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface ITripService
    {
        Task<TripDto> CreateTripAsync(TripForCreateDto trip);
        Task<bool> DeleteTripAsync(int tripId);
        Task<TripDto?> GetTripAsync(int tripId);
        Task<IEnumerable<TripDto>> GetTripsAsync();
        Task<bool> UpdateTripAsync(int tripId, TripForUpdateDto trip);
    }
}