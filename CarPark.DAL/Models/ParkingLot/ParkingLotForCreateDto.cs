using System.ComponentModel.DataAnnotations;

namespace CarPark.DAL.Models
{
    public class ParkingLotForCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string? ParkArea { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ParkName { get; set; }

        [Required]
        [MaxLength(11)]
        public string? ParkPlace { get; set; }

        [Required]
        public int ParkPrice { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ParkStatus { get; set; }
    }
}