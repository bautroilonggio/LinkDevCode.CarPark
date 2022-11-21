using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Entities
{
    public class ParkingLot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkId { get; set; }

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

        public ICollection<Car> Cars { get; set; }
                = new List<Car>();

        //public ParkingLot(string parkingName, string place,
        //                  string area, string status)
        //{
        //    ParkName = parkingName;
        //    ParkPlace = place;
        //    ParkArea = area;
        //    ParkStatus = status;
        //}
    }
}
