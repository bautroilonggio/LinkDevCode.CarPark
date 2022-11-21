using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using CarPark.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Repositories
{
    public class BookingOfficeRepository : RepositoryBase<BookingOffice>, IBookingOfficeRepository
    {
        private readonly CarParkContext _context;

        public BookingOfficeRepository(CarParkContext context) 
            : base(context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }


    }
}
