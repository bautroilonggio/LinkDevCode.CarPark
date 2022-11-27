using AutoMapper;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

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

            CreateMap<TicketForCreateDto, Ticket>();
            CreateMap<TicketForUpdateDto, Ticket>();
        }
    }
}