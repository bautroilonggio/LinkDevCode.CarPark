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
