using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class ResponseAPI
    {
        public bool Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
