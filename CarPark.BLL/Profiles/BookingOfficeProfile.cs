using AutoMapper;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
