using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class EmployeeDetailDto
    {
        public string? Account { get; set; }

        public string? Department { get; set; }

        public string? EmployeeAddress { get; set; }

        public DateOnly EmployeeBirthday { get; set; }

        public string? EmployeeEmail { get; set; }

        public string? EmployeeName { get; set; }

        public string? EmployeePhone { get; set; }

        public string? Password { get; set; }

        public string? Sex { get; set; }
    }
}
