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
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>()
                .ForMember(destination => destination.LicensePlate,
                           options => options.MapFrom(source => source.LicensePlate))
                .ForMember(destination => destination.Destination,
                           options => options.MapFrom(source => source.Trip.Destination));

            CreateMap<TicketFroCreateDto, Ticket>();
        }
    }
}
