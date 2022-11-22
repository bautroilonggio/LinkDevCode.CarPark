using AutoMapper;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDto>()
                .ForMember(destination => destination.ParkName,
                            options => options.MapFrom(source => source.ParkingLot.ParkName));

            //CreateMap<CarFroCreateDto, Car>()
            //    .ForMember(destination => destination.ParkingLot.ParkName,
            //                options => options.MapFrom(source => source.ParkName));

            //CreateMap<CarFroCreateDto, Car>()
            //    .ForMember(destination => destination.ParkingLot,
            //                options => options.MapFrom(source => new ParkingLot { ParkName = source.ParkName}));

            CreateMap<CarFroCreateDto, Car>();

            CreateMap<CarForUpdateDto, Car>();
        }
    }
}