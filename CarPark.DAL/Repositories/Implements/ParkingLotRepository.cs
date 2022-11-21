using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Repositories
{
    public class ParkingLotRepository : RepositoryBase<ParkingLot>, IParkingLotRepository
    {
        private readonly CarParkContext _context;
        public ParkingLotRepository(CarParkContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ParkingLot?> GetParkingLotByName(string parkName)
        {
            return await _context.ParkingLots
                        .Where(p => p.ParkName == parkName)
                        .FirstOrDefaultAsync();
        }
    }
}
