using CarPark.DAL.DbContexts;
using CarPark.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarPark.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDALServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<CarParkContext>(
                dbContextOptions => dbContextOptions.UseSqlServer(
                    "Data Source=LINK\\KHACLINH;Initial Catalog=CarParkDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true"));

            return services;
        }
    }
}