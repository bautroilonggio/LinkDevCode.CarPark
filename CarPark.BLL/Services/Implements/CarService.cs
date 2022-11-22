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

        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<CarDto>> GetCarsAsync()
        {
            var carEntities = await _unitOfWork.CarRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDto>>(carEntities);
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

        public async Task<CarDto> CreateCarAsync(CarFroCreateDto car)
        {
            var parkEntity = await _unitOfWork.ParkingLotRepository
                                   .GetSingleConditionsAsync(park => park.ParkName == car.ParkName);
            car.ParkId = parkEntity.ParkId;

            var carEntity = _mapper.Map<Car>(car);

            _unitOfWork.CarRepository.Add(carEntity);

            await _unitOfWork.ComitAsync();

            return _mapper.Map<CarDto>(carEntity);
        }

        public async Task<bool> UpdateCarAsync(string licensePlate, CarForUpdateDto car)
        {
            var carEntity = await _unitOfWork.CarRepository.GetSingleAsync(licensePlate);

            if (carEntity == null)
            {
                return false;
            }

            var parkEntity = await _unitOfWork.ParkingLotRepository
                                   .GetSingleConditionsAsync(park => park.ParkName == car.ParkName);
            car.ParkId = parkEntity.ParkId;

            _mapper.Map(car, carEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }

        public async Task<bool> DeleteCarAsync(string licensePlate)
        {
            var carEntity = await _unitOfWork.CarRepository.GetSingleAsync(licensePlate);

            if (carEntity == null)
            {
                return false;
            }

            _unitOfWork.CarRepository.Delete(carEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }
    }
}