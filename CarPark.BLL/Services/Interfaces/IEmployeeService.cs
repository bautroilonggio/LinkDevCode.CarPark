using CarPark.DAL.Models;

namespace CarPark.BLL.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeForCreateDto employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
        Task<EmployeeDto?> GetEmployeeAsync(int employeeId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<bool> UpdateEmployeeAsync(int employeeId, EmployeeForUpdateDto employee);
    }
}