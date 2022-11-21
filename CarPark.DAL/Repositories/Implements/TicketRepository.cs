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
    public class TicketRepository : RepositoryBase<Ticket>, ITicketRepository
    {
        private readonly CarParkContext _context;

        public TicketRepository(CarParkContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public override async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets
                         .Include(ticket => ticket.Trip)
                         .Include(ticket => ticket.Car)
                         .ToListAsync();
        }

        public override async Task<Ticket?> GetSingleAsync(object ticketId)
        {
            return await _context.Tickets
                         .Include(ticket => ticket.Trip)
                         .Include(ticket => ticket.Car)
                         .Where(ticket => ticket.TicketId == (int)ticketId)
                         .FirstOrDefaultAsync();
        }
    }
}
