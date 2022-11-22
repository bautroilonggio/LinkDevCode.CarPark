using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPark.DAL.Entities
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        [Required]
        public TimeOnly BookingTime { get; set; }

        [MaxLength(50)]
        public string? CustomerName { get; set; }

        [ForeignKey("LicensePlate")]
        public Car? Car { get; set; }

        [MaxLength(50)]
        public string? LicensePlate { get; set; }

        [ForeignKey("TripId")]
        public Trip? Trip { get; set; }

        [MaxLength(50)]
        public int TripId { get; set; }

        //public Ticket(string licensePlate, string customer)
        //{
        //    LicensePlate = licensePlate;
        //    CustomerName = customer;
        //}
    }
}