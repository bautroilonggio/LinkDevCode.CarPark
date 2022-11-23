using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarPark.DAL.DbContexts
{
    public class CarParkContext : DbContext
    {
        public DbSet<BookingOffice> BookingOffices { get; set; } = null!;

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<ParkingLot> ParkingLots { get; set; } = null!;

        public DbSet<Ticket> Tickets { get; set; } = null!;

        public DbSet<Trip> Trips { get; set; } = null!;

        public CarParkContext(DbContextOptions<CarParkContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");
        }
    }

    public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        { }
    }

    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
                timeOnly => timeOnly.ToTimeSpan(),
                timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        { }
    }
}