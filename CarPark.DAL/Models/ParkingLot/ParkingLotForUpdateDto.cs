using System.ComponentModel.DataAnnotations;

namespace CarPark.DAL.Models
{
    public class ParkingLotForUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string? ParkArea { get; set; }

        [Required]
        [MaxLength(50)]
        public string? ParkName { get; set; }

        [Required]
        public string? ParkPlace { get; set; }

        [Required]
        public int ParkPrice { get; set; }
    }
}