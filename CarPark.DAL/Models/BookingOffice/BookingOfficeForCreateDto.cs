using CarPark.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace CarPark.DAL.Models
{
    public class BookingOfficeForCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string? OfficeName { get; set; }

        [Required]
        [MaxLength(11)]
        public string? OfficePhone { get; set; }

        [Required]
        [MaxLength(50)]
        public string? OfficePlace { get; set; }

        [Required]
        public int OfficePrice { get; set; }

        [Required]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly StartContractDeadline { get; set; }

        [Required]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly EndContractDeadline { get; set; }

        [Required]
        public int TripId { get; set; }
    }
}
