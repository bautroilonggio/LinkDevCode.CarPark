using System.ComponentModel.DataAnnotations;

namespace CarPark.DAL.Models
{
    public class TripForUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string? CarType { get; set; }

        [Required]
        public DateOnly DepartureDate { get; set; }

        [Required]
        public TimeOnly DepartureTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Destination { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Driver { get; set; }

        [Required]
        public int MaximumOnlineTicketNumber { get; set; }
    }
}