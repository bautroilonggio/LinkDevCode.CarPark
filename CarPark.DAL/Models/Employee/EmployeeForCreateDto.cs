using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class EmployeeForCreateDto
    {
        [MaxLength(50)]
        public string? Account { get; set; }

        [MaxLength(10)]
        public string? Department { get; set; }

        [MaxLength(50)]
        public string? EmployeeAddress { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly EmployeeBirthday { get; set; }

        [MaxLength(50)]
        public string? EmployeeEmail { get; set; }

        [MaxLength(50)]
        public string? EmployeeName { get; set; }

        [MaxLength(10)]
        public string? EmployeePhone { get; set; }

        [MaxLength(20)]
        public string? Password { get; set; }

        [MaxLength(10)]
        public string? Sex { get; set; }
    }
}
