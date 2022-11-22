using AutoMapper;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Profiles
{
    public class BookingOfficeProfile : Profile
    {
        public BookingOfficeProfile()
        {
            CreateMap<BookingOffice, BookingOfficeDto>()
                .ForMember(destination => destination.Destination,
                           options => options.MapFrom(source => source.Trip.Destination));

            CreateMap<BookingOffice, BookingOfficeDetailDto>()
                .ForMember(destination => destination.Destination,
                           options => options.MapFrom(source => source.Trip.Destination));

            CreateMap<BookingOfficeForCreateDto, BookingOffice>();
        }
    }
}