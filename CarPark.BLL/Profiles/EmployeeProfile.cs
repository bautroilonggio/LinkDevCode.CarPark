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
