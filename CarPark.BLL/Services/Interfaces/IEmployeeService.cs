using CarPark.DAL;
using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeForCreateDto employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
        Task<EmployeeDetailDto?> GetEmployeeAsync(int employeeId);
        Task<(IEnumerable<EmployeeDto>, PaginationMetadata)> GetEmployeesAsync(
            string? employeeName, string? searchQuery, int pageNumber, int pageSize);
        Task<bool> UpdateEmployeeAsync(int employeeId, EmployeeForUpdateDto employee);
    }
}