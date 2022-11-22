using CarPark.DAL;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface IParkingLotService
    {
        Task<(IEnumerable<ParkingLotDto>, PaginationMetadata)> GetParkingLotsAsync(
            string? parkName, string? searchQuery, int pageNumber, int pageSize);
        Task<IEnumerable<ParkingLotDto>?> GetParkingLotsEmptyAsync();
        Task<ParkingLotDto?> GetParkingLotAsync(int parkingLotId);
        Task<ParkingLotDto> CreateParkingLotAsync(ParkingLotForCreateDto parkingLot);
        Task<bool> UpdateParkingLotAsync(int parkingLotId, ParkingLotForUpdateDto parkingLot);
        Task<bool> DeleteParkingLotAsync(int parkingLotId);
    }
}