using AutoMapper;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserToReturnDto>();
        }
    }
}
