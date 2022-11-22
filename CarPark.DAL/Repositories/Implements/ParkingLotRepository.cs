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
        public ParkingLotRepository(CarParkContext context) : base(context)
        {
           
        }
    }
}
