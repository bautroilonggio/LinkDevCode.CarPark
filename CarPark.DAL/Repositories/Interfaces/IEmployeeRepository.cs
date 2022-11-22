using CarPark.DAL.Entities;

namespace CarPark.DAL.Repositories
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<(IEnumerable<Employee>, PaginationMetadata)> GetAllAsync(
            string? employeeName, string? searchQuery, int pageNumber, int pageSize);
    }
}