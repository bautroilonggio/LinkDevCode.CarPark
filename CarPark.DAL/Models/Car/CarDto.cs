using CarPark.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class CarDto
    {
        public string? LicensePlate { get; set; }

        public string? CarType { get; set; }

        public string? CarColor { get; set; }

        public string? Company { get; set; }

        public string? ParkName { get; set; }
    }
}
