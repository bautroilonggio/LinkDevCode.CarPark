using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class UserForRegisterDto
    {
        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Lastname { get; set; }

        [Required]
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Address { get; set; }
    }
}
