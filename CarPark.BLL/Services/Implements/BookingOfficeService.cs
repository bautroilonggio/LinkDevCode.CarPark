using AutoMapper;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public class BookingOfficeService : IBookingOfficeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int _maxBookingOfficePageSize = 20;

        public BookingOfficeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<(IEnumerable<BookingOfficeDto>, PaginationMetadata)> GetBookingOfficesAsync(
            string? officeName, string? searchQuery, int pageNumber, int pageSize)
        {
            if(pageSize > _maxBookingOfficePageSize)
            {
                pageSize = _maxBookingOfficePageSize;
            }

            var (bookingOfficeEntities, paginationMetadata) = await _unitOfWork.BookingOfficeRepository.GetAllAsync(
                                                                    officeName, searchQuery, pageNumber, pageSize);

            var bookingOffices = _mapper.Map<IEnumerable<BookingOfficeDto>>(bookingOfficeEntities);

            return (bookingOffices, paginationMetadata);
        }

        public async Task<BookingOfficeDetailDto?> GetBookingOfficeAsync(int officeId)
        {
            var bookingOfficeEntity = await _unitOfWork.BookingOfficeRepository.GetSingleAsync(officeId);

            if (bookingOfficeEntity == null)
            {
                return null;
            }

            return _mapper.Map<BookingOfficeDetailDto>(bookingOfficeEntity);
        }

        public async Task<BookingOfficeDetailDto> CreateBookingOfficeAsync(BookingOfficeForCreateDto bookingOffice)
        {
            var tripEntity = await _unitOfWork.TripRepository
                                   .GetSingleConditionsAsync(trip => trip.Destination == bookingOffice.Destination);
            bookingOffice.TripId = tripEntity.TripId;

            var bookingOfficeEntity = _mapper.Map<BookingOffice>(bookingOffice);

            _unitOfWork.BookingOfficeRepository.Add(bookingOfficeEntity);

            await _unitOfWork.ComitAsync();

            return _mapper.Map<BookingOfficeDetailDto>(bookingOfficeEntity);
        }

        public async Task<bool> DeleteBookingOfficeAsync(int officeId)
        {
            var bookingOfficeEntity = await _unitOfWork.BookingOfficeRepository.GetSingleAsync(officeId);

            if (bookingOfficeEntity == null)
            {
                return false;
            }

            _unitOfWork.BookingOfficeRepository.Delete(bookingOfficeEntity);

            await _unitOfWork.ComitAsync();

            return true;
        }
    }
}