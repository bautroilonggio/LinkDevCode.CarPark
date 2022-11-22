using AutoMapper;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

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