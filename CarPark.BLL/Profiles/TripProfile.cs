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
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trip, TripDto>();

            CreateMap<TripDto, Trip>();

            CreateMap<TripForCreateDto, Trip>();

            CreateMap<TripForUpdateDto, Trip>();
        }
    }
}
