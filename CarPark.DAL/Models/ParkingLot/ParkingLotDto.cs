using CarPark.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace CarPark.DAL.Models
{
    public class ParkingLotDto
    {
        public int ParkId { get; set; }

        public string? ParkArea { get; set; }

        public string? ParkName { get; set; }

        public string? ParkPlace { get; set; }

        public int ParkPrice { get; set; }

        public string? ParkStatus { get; set; }
    }
}