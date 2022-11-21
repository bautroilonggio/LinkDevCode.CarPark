using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class BookingOfficeDto
    {
        public int OfficeId { get; set; }

        public string? OfficeName { get; set; }

        public string? Destination { get; set; }
    }
}
