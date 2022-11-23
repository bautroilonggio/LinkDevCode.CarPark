using AutoMapper;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int _maxBookingOfficePageSize = 20;

        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<(IEnumerable<CarDto>, PaginationMetadata)> GetCarsAsync(
            string? licensePlate, string? searchQuery, int pageNumber, int pageSize)
        {
            if (pageSize > _maxBookingOfficePageSize)
            {
                pageSize = _maxBookingOfficePageSize;
            }

            var (carEntities, paginationMetadata) = await _unitOfWork.CarRepository.GetAllAsync(
                                                          licensePlate, searchQuery, pageNumber, pageSize);

            var cars = _mapper.Map<IEnumerable<CarDto>>(carEntities);

            return (cars, paginationMetadata);
        }

        public async Task<CarDto?> GetCarAsync(string licensePlate)
        {
            var carEntity = await _unitOfWork.CarRepository.GetSingleAsync(licensePlate);

            if (carEntity == null)
            {
                return null;
            }

            return _mapper.Map<CarDto>(carEntity);
        }

        public async Task<CarDto?> CreateCarAsync(string parkName, CarFroCreateDto car)
        {
            var parkingLotEntity = await _unitOfWork.ParkingLotRepository
                                         .GetParkingLotIncludeCars(p => p.ParkName == parkName);

            if(parkingLotEntity == null)
            {
                return null;
            }

            var carEntity = _mapper.Map<Car>(car);

            _unitOfWork.CarRepository.Add(parkingLotEntity, carEntity);

            await _unitOfWork.ComitAsync();

            return _mapper.Map<CarDto>(carEntity);
        }

        public async Task<bool> UpdateCarAsync(string parkName, string licensePlate, CarForUpdateDto car)
        {
            var parkingLotEntity = await _unitOfWork.ParkingLotRepository
                                         .GetParkingLotIncludeCars(p => p.ParkName == parkName);

            if (parkingLotEntity == null)
            {
                return false;
            }

            var carEntity = await _unitOfWork.CarRepository.GetSingleAsync(licensePlate);

            if (carEntity == null)
            {
                return false;
            }

            _mapper.Map(car, carEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }

        public async Task<bool> DeleteCarAsync(string parkName, string licensePlate)
        {
            var parkingLotEntity = await _unitOfWork.ParkingLotRepository
                                         .GetSingleConditionsAsync(p => p.ParkName == parkName);

            if (parkingLotEntity == null)
            {
                return false;
            }

            var carEntity = await _unitOfWork.CarRepository.GetSingleAsync(licensePlate);

            if (carEntity == null)
            {
                return false;
            }

            _unitOfWork.CarRepository.Delete(parkingLotEntity, carEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }
    }
}