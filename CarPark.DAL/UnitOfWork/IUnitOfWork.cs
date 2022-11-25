using CarPark.DAL.Repositories;
using CarPark.DAL.Repositories.Interfaces;

namespace CarPark.DAL
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IEmployeeRepository EmployeeRepository { get; }

        IParkingLotRepository ParkingLotRepository { get; }

        ITripRepository TripRepository { get; }

        ICarRepository CarRepository { get; }

        ITicketRepository TicketRepository { get; }

        IBookingOfficeRepository BookingOfficeRepository { get; }

        Task ComitAsync();
    }
}