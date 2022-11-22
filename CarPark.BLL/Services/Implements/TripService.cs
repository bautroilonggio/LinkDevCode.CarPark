using AutoMapper;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public class TripService : ITripService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TripService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TripDto>> GetTripsAsync()
        {
            var tripEntities = await _unitOfWork.TripRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TripDto>>(tripEntities);
        }

        public async Task<TripDto?> GetTripAsync(int tripId)
        {
            var tripEntity = await _unitOfWork.TripRepository.GetSingleAsync(tripId);

            if (tripEntity == null)
            {
                return null;
            }

            return _mapper.Map<TripDto>(tripEntity);
        }

        public async Task<TripDto> CreateTripAsync(TripForCreateDto trip)
        {
            var tripEntity = _mapper.Map<Trip>(trip);

            _unitOfWork.TripRepository.Add(tripEntity);

            await _unitOfWork.ComitAsync();

            return _mapper.Map<TripDto>(tripEntity);
        }

        public async Task<bool> UpdateTripAsync(int tripId, TripForUpdateDto trip)
        {
            var tripEntity = await _unitOfWork.TripRepository.GetSingleAsync(tripId);

            if (tripEntity == null)
            {
                return false;
            }

            _mapper.Map(trip, tripEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }

        public async Task<bool> DeleteTripAsync(int tripId)
        {
            var tripEntity = await _unitOfWork.TripRepository.GetSingleAsync(tripId);

            if (tripEntity == null)
            {
                return false;
            }

            _unitOfWork.TripRepository.Delete(tripEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }
    }
}