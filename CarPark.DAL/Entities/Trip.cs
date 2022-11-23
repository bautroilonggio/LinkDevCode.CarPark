using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPark.DAL.Entities
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TripId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Destination { get; set; }

        [Required]
        public DateOnly DepartureDate { get; set; }

        [Required]
        public TimeOnly DepartureTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Driver { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CarType { get; set; }

        [Required]
        public int BookedTicketNumber { get; set; }

        public int MaximumOnlineTicketNumber { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
                = new List<Ticket>();

        public ICollection<BookingOffice> BookingOffices { get; set; }
                = new List<BookingOffice>();
    }
}