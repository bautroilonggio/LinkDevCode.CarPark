namespace CarPark.DAL.Models
{
    public class BookingOfficeDetailDto
    {
        public int OfficeId { get; set; }

        public string? OfficeName { get; set; }

        public string? OfficePhone { get; set; }

        public string? OfficePlace { get; set; }

        public int OfficePrice { get; set; }

        public DateOnly StartContractDeadline { get; set; }

        public DateOnly EndContractDeadline { get; set; }

        public string? Destination { get; set; }
    }
}