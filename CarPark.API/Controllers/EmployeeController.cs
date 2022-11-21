using CarPark.BLL.Services;
using CarPark.DAL.Entities;
using CarPark.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarPark.API.Controllers
{
    [Route("api/employees")]
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
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
        {
            return Ok(await _employeeService.GetEmployeesAsync());
        }

        [HttpGet("{employeeId}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeAsync(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeAsync(employeeId);

            if(employee == null)
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
