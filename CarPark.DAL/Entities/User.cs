﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPark.DAL.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

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

        [Required]
        public string? Role { get; set; }
    }
}
