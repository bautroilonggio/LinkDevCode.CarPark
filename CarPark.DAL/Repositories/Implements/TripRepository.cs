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
        public TripRepository(CarParkContext context) : base(context)
        {
            
        }
    }
}
