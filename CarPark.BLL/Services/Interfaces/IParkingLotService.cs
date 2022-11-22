using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface IParkingLotService
    {
        Task<ParkingLotDto> CreateParkingLotAsync(ParkingLotForCreateDto parkingLot);

        Task<bool> DeleteParkingLotAsync(int parkingLotId);

        Task<ParkingLotDto?> GetParkingLotAsync(int parkingLotId);

        Task<IEnumerable<ParkingLotDto>> GetParkingLotsAsync();

        Task<IEnumerable<ParkingLotDto>> GetParkingLotsEmptyAsync();

        Task<bool> UpdateParkingLotAsync(int parkingLotId, ParkingLotForUpdateDto parkingLot);
    }
}