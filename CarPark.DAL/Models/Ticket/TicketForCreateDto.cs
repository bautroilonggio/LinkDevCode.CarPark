using CarPark.DAL.Commons;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarPark.DAL.Models
{
    public class TicketForCreateDto
    {
        [Required]
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly BookingTime { get; set; }

        [MaxLength(50)]
        public string? CustomerName { get; set; }

        //[MaxLength(50)]
        //public string? LicensePlate { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string? Destination { get; set; }

        //[JsonIgnore]
        //public int TripId { get; set; }
    }
}