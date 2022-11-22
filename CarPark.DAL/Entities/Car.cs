using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPark.DAL.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(50)]
        public string? LicensePlate { get; set; }

        [MaxLength(50)]
        public string? CarType { get; set; }

        [MaxLength(11)]
        public string? CarColor { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Company { get; set; }

        [ForeignKey("ParkId")]
        public ParkingLot? ParkingLot { get; set; }

        [Required]
        public int ParkId { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
                = new List<Ticket>();

        //public Car(string licensePlate, string type,
        //           string color, string company)
        //{
        //    LicensePlate = licensePlate;
        //    CarType = type;
        //    CarColor = color;
        //    Company = company;
        //}
    }
}