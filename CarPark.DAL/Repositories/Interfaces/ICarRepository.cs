using CarPark.DAL.Entities;
using CarPark.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Repositories
{
    public interface ICarRepository : IRepositoryBase<Car>
    {
        //Task<IEnumerable<Car>> GetCarsAsync();
    }
}
