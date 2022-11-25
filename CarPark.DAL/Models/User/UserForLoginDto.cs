using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class UserForLoginDto
    {
        [Required]
        [MaxLength(100)]
        public string? UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
