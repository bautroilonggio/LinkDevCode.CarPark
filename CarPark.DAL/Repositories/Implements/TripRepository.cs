using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Repositories
{
    public class TripRepository : RepositoryBase<Trip>, ITripRepository
    {
        private readonly CarParkContext _context;

        public TripRepository(CarParkContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Trip?> GetTripByDestination(string destination)
        {
            return await _context.Trips
                         .Where(trip => trip.Destination == destination)
                         .FirstOrDefaultAsync();
        }
    }
}
