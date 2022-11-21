using CarPark.DAL.Repositories;
using CarPark.DAL.Repositories.Interfaces;

namespace CarPark.DAL
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }

        IParkingLotRepository ParkingLotRepository { get; }

        ITripRepository TripRepository { get; }

        ICarRepository CarRepository { get; }

        ITicketRepository TicketRepository { get; }

        IBookingOfficeRepository BookingOfficeRepository { get; }

        Task ComitAsync();
    }
}