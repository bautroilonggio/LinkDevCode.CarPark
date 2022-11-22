namespace CarPark.DAL.Models
{
    public class TripDto
    {
        public int TripId { get; set; }

        public int BookedTicketNumber { get; set; }

        public string? CarType { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public string? Destination { get; set; }

        public string? Driver { get; set; }
    }
}