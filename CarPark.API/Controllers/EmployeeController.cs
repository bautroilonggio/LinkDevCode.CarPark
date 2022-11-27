using CarPark.BLL.Services;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarPark.API.Controllers
{
    [Route("api/employees")]
    //[Authorize(Policy = "MustBeAdmin")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ??
                throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync(
            string? employeeName, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var (employees, paginationMetadata) = await _employeeService
                .GetEmployeesAsync(employeeName, searchQuery, pageNumber, pageSize);

            Response.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            if(employees.Count() == 0)
            {
                return NotFound();
            }

            return Ok(employees);
        }

        [HttpGet("{employeeId}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDetailDto>> GetEmployeeAsync(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeAsync(employeeId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployeeAsync(EmployeeForCreateDto employee)
        {
            var createEmployeeToReturn = await _employeeService.CreateEmployeeAsync(employee);

            if (createEmployeeToReturn == null)
            {
                return BadRequest();
            }

            return CreatedAtRoute(
                    "GetEmployeeById",
                    new
                    {
                        employeeId = createEmployeeToReturn.EmployeeId
                    },
                    createEmployeeToReturn);
        }

        [HttpPut("{employeeId}")]
        public async Task<ActionResult> UpdateEmployeeAsync(int employeeId, EmployeeForUpdateDto employee)
        {
            if (!await _employeeService.UpdateEmployeeAsync(employeeId, employee))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int employeeId)
        {
            if (!await _employeeService.DeleteEmployeeAsync(employeeId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}