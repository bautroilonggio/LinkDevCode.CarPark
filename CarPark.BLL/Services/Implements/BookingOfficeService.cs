using AutoMapper;
using CarPark.DAL;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.BLL.Services
{
    public class BookingOfficeService : IBookingOfficeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingOfficeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<BookingOfficeDto>> GetBookingOfficesAsync()
        {
            var bookingOfficeEntities = await _unitOfWork.BookingOfficeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookingOfficeDto>>(bookingOfficeEntities);
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
            var tripEntity = await _unitOfWork.TripRepository.GetTripByDestination(bookingOffice.Destination);
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
