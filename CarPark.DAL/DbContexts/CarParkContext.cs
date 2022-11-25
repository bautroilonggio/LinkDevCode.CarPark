using CarPark.DAL.Commons;
using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarPark.DAL.DbContexts
{
    public class CarParkContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

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
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.HasIndex(e => e.PhoneNumber).IsUnique();
            });

            modelBuilder.Entity<ParkingLot>(entity =>
            {
                entity.HasIndex(e => e.ParkName).IsUnique();
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasIndex(e => e.Destination).IsUnique();
            });

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
}