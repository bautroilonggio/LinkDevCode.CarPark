using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarPark.DAL.Models
{
    public class CarFroCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string? LicensePlate { get; set; }

        [MaxLength(50)]
        public string? CarType { get; set; }

        [MaxLength(11)]
        public string? CarColor { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Company { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string? ParkName { get; set; }

        //[Required]
        //[JsonIgnore]
        //public int ParkId { get; set; }
    }
}