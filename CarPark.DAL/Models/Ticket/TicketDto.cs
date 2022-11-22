using System.ComponentModel.DataAnnotations;

namespace CarPark.DAL.Models
{
    public class TicketDto
    {
        public int TicketId { get; set; }

        [Required]
        public TimeOnly BookingTime { get; set; }

        [MaxLength(50)]
        public string? CustomerName { get; set; }

        [MaxLength(50)]
        public string? LicensePlate { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Destination { get; set; }
    }
}