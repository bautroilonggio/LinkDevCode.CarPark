﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarPark.DAL.Models
{
    public class TripForCreateDto
    {
        [Required]
        public int BookedTicketNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CarType { get; set; }

        [Required]
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly DepartureDate { get; set; }

        [Required]
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly DepartureTime { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Destination { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Driver { get; set; }

        public int MaximumOnlineTicketNumber { get; set; }
    }
}