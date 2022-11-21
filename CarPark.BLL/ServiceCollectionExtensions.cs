using CarPark.BLL.Services;
using CarPark.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.BLL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterBLLServices(this IServiceCollection services)
        {
            services.RegisterDALServices();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IParkingLotService, ParkingLotService>();
            services.AddScoped<ITripService, TripService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ITicketService, TicketService>();

            return services;
        }
    }
}
