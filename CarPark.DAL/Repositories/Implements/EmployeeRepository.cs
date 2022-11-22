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
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        private readonly CarParkContext _context;

        public EmployeeRepository(CarParkContext context) : base(context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<(IEnumerable<Employee>, PaginationMetadata)> GetAllAsync(
            string? employeeName, string? searchQuery, int pageNumber, int pageSize)
        {
            //if (string.IsNullOrEmpty(employeeName)
            //    && string.IsNullOrWhiteSpace(searchQuery))
            //{
            //    return await GetAllAsync();
            //}

            // collection to start from
            var collection = _context.Employees as IQueryable<Employee>;

            if (!string.IsNullOrWhiteSpace(employeeName))
            {
                employeeName = employeeName.Trim();
                collection = collection.Where(e => e.EmployeeName == employeeName);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.EmployeeName.Contains(searchQuery)
                                           || (a.Account != null && a.Account.Contains(searchQuery))
                                           || (a.Department != null && a.Department.Contains(searchQuery))
                                           || (a.EmployeeAddress!= null && a.EmployeeAddress.Contains(searchQuery))
                                           || (a.EmployeeEmail != null && a.EmployeeEmail.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var painationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var colectionToReturn = await collection.Skip(pageSize * (pageNumber - 1))
                                   .Take(pageSize)
                                   .ToListAsync();

            return (colectionToReturn, painationMetadata);

            //employeeName = employeeName.Trim();
            //return await _context.Employees
            //             .Where(e => e.EmployeeName == employeeName)
            //             .ToListAsync();
        }
    }
}
