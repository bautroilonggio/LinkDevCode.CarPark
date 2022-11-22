using AutoMapper;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;

namespace CarPark.BLL.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();

            CreateMap<Employee, EmployeeDetailDto>();

            CreateMap<EmployeeForCreateDto, Employee>();

            CreateMap<EmployeeForUpdateDto, Employee>();
        }
    }
}