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
    public class TicketFroCreateDto
    {
        [Required]
        public TimeOnly BookingTime { get; set; }

        [MaxLength(50)]
        public string? CustomerName { get; set; }

        [MaxLength(50)]
        public string? LicensePlate { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Destination { get; set; }

        [JsonIgnore]
        public int TripId { get; set; }
    }
}
