using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarPark.DAL.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Account { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Department { get; set; }

        [MaxLength(50)]
        public string? EmployeeAddress { get; set; }

        [Required]
        public DateOnly EmployeeBirthday { get; set; }

        [MaxLength(50)]
        public string? EmployeeEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string? EmployeeName { get; set; }

        [Required]
        [MaxLength(10)]
        public string? EmployeePhone { get; set; }

        [Required]
        [MaxLength(20)]
        public string? Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Sex { get; set; }

        //public Employee(string fullName, string sex, string address, string phoneNumber,
        //                string email, string account, string password, string department)
        //{
        //    EmployeeName = fullName;
        //    Sex = sex;
        //    EmployeeEmail = email;
        //    EmployeeAddress = address;
        //    EmployeePhone = phoneNumber;
        //    EmployeeEmail = email;
        //    Account = account;
        //    Password = password;
        //    Department = department;
        //}
    }
}
