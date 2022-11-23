using CarPark.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CarPark.DAL
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDALServices(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration configuration = builder.Build();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<CarParkContext>(
                dbContextOptions => dbContextOptions.UseSqlServer(
                    configuration.GetConnectionString("CarParkDBConnectionString")));

            return services;
        }
    }
}