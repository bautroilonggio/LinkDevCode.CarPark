using CarPark.DAL.Repositories;

namespace CarPark.DAL
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }

        IParkingLotRepository ParkingLotRepository { get; }

        ITripRepository TripRepository { get; }

        ICarRepository CarRepository { get; }

        ITicketRepository TicketRepository { get; }

        Task ComitAsync();
    }
}