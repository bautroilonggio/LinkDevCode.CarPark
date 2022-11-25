using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CarParkContext context) : base(context)
        {
        }
    }
}
