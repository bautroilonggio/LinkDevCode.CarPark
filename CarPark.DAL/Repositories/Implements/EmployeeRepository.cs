using CarPark.DAL.DbContexts;
using CarPark.DAL.Entities;
using Microsoft.EntityFrameworkCore;

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
                collection = collection.Where(e => e.EmployeeName.Contains(searchQuery)
                                           || (e.Department != null && e.Department.Contains(searchQuery))
                                           || (e.EmployeeAddress != null && e.EmployeeAddress.Contains(searchQuery))
                                           || (e.EmployeePhone != null && e.EmployeePhone.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var colectionToReturn = await collection.Skip(pageSize * (pageNumber - 1))
                                                    .Take(pageSize)
                                                    .ToListAsync();

            return (colectionToReturn, paginationMetadata);

            //employeeName = employeeName.Trim();
            //return await _context.Employees
            //             .Where(e => e.EmployeeName == employeeName)
            //             .ToListAsync();
        }
    }
}