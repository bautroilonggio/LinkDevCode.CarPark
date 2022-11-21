using CarPark.DAL.DbContexts;
using CarPark.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CarParkContext _context;

        private IEmployeeRepository? _employeeRepository;
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_context);
                }
                return _employeeRepository;
            }
        }


        private IParkingLotRepository? _parkingLotRepository;
        public IParkingLotRepository ParkingLotRepository
        {
            get
            {
                if (_parkingLotRepository == null)
                {
                    _parkingLotRepository = new ParkingLotRepository(_context);
                }
                return _parkingLotRepository;
            }
        }


        private ITripRepository? _tripRepository;
        public ITripRepository TripRepository
        {
            get
            {
                if (_tripRepository == null)
                {
                    _tripRepository = new TripRepository(_context);
                }
                return _tripRepository;
            }
        }


        private ICarRepository? _carRepository;
        public ICarRepository CarRepository
        {
            get
            {
                if (_carRepository == null)
                {
                    _carRepository = new CarRepository(_context);
                }
                return _carRepository;
            }
        }


        private ITicketRepository? _ticketRepository;
        public ITicketRepository TicketRepository
        {
            get
            {
                if (_ticketRepository == null)
                {
                    _ticketRepository = new TicketRepository(_context);
                }
                return _ticketRepository;
            }
        }

        public UnitOfWork(CarParkContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task ComitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
