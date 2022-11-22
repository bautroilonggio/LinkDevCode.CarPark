using AutoMapper;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Profiles
{
    public class ParkingLotProfile : Profile
    {
        public ParkingLotProfile()
        {
            CreateMap<ParkingLot, ParkingLotDto>();

            CreateMap<ParkingLotDto, ParkingLot>();

            CreateMap<ParkingLotForCreateDto, ParkingLot>();

            CreateMap<ParkingLotForUpdateDto, ParkingLot>();
        }
    }
}