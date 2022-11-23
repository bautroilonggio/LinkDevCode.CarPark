using CarPark.DAL;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface ICarService
    {
        Task<(IEnumerable<CarDto>, PaginationMetadata)> GetCarsAsync(
            string? licensePlate, string? searchQuery, int pageNumber, int pageSize);

        Task<CarDto?> GetCarAsync(string licensePlate);

        Task<CarDto?> CreateCarAsync(string parkName, CarFroCreateDto car);

        Task<bool> UpdateCarAsync(string parkName, string licensePlate, CarForUpdateDto car);

        Task<bool> DeleteCarAsync(string parkName, string licensePlate);
    }
}