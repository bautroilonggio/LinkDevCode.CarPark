using AutoMapper;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int _maxParkingLotPageSize = 20;

        public ParkingLotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<(IEnumerable<ParkingLotDto>, PaginationMetadata)> GetParkingLotsAsync(
            string? parkName, string? searchQuery, int pageNumber, int pageSize)
        {
            if(pageSize > _maxParkingLotPageSize)
            {
                pageSize = _maxParkingLotPageSize;
            }

            var (parkingLotEntities, paginationMetadata) = await _unitOfWork.ParkingLotRepository.GetAllAsync(
                                                                 parkName, searchQuery, pageNumber, pageSize);

            var parkingLots = _mapper.Map<IEnumerable<ParkingLotDto>>(parkingLotEntities);

            return (parkingLots, paginationMetadata);
        }

        public async Task<IEnumerable<ParkingLotDto>?> GetParkingLotsEmptyAsync()
        {
            var parkingLotEntities = await _unitOfWork.ParkingLotRepository
                                                .GetManyAsync(p => p.ParkStatus == "Empty");

            if(parkingLotEntities == null)
            {
                return null;
            }

            return _mapper.Map<IEnumerable<ParkingLotDto>>(parkingLotEntities);
        }

        public async Task<ParkingLotDto?> GetParkingLotAsync(int parkingLotId)
        {
            var parkingLotEntity = await _unitOfWork.ParkingLotRepository.GetSingleAsync(parkingLotId);

            if (parkingLotEntity == null)
            {
                return null;
            }

            return _mapper.Map<ParkingLotDto>(parkingLotEntity);
        }

        public async Task<ParkingLotDto> CreateParkingLotAsync(ParkingLotForCreateDto parkingLot)
        {
            var parkingLotEntity = _mapper.Map<ParkingLot>(parkingLot);

            _unitOfWork.ParkingLotRepository.Add(parkingLotEntity);

            await _unitOfWork.ComitAsync();

            return _mapper.Map<ParkingLotDto>(parkingLotEntity);
        }

        public async Task<bool> UpdateParkingLotAsync(int parkingLotId, ParkingLotForUpdateDto parkingLot)
        {
            var parkingLotEntity = await _unitOfWork.ParkingLotRepository.GetSingleAsync(parkingLotId);

            if (parkingLotEntity == null)
            {
                return false;
            }

            _mapper.Map(parkingLot, parkingLotEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }

        public async Task<bool> DeleteParkingLotAsync(int parkingLotId)
        {
            var parkingLotEntity = await _unitOfWork.ParkingLotRepository.GetSingleAsync(parkingLotId);

            if (parkingLotEntity == null)
            {
                return false;
            }

            _unitOfWork.ParkingLotRepository.Delete(parkingLotEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }
    }
}