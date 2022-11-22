using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPark.DAL.Entities
{
    public class BookingOffice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfficeId { get; set; }

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
        public DateOnly StartContractDeadline { get; set; }

        [Required]
        public DateOnly EndContractDeadline { get; set; }

        [ForeignKey("TripId")]
        public Trip? Trip { get; set; }

        [Required]
        public int TripId { get; set; }

        //public BookingOffice(string name, string phoneNumber, string place)
        //{
        //    OfficeName = name;
        //    OfficePhone = phoneNumber;
        //    OfficePlace = place;
        //}
    }
}