using System.ComponentModel.DataAnnotations;

namespace CarPark.DAL.Models
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        [MaxLength(10)]
        public string? Department { get; set; }

        [MaxLength(50)]
        public string? EmployeeAddress { get; set; }

        public DateOnly EmployeeBirthday { get; set; }

        [MaxLength(50)]
        public string? EmployeeName { get; set; }

        [MaxLength(10)]
        public string? EmployeePhone { get; set; }
    }
}