using Microsoft.AspNetCore.Identity;

namespace mockexam.Models
{
    public class Bookings
    {
        public int BookingsId { get; set; }
        public string UserId { get; set; }
        public Rooms? Rooms { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public int? NumberOfGuests { get; set; }
        public string? Status { get; set; }
        public DateTime BookingCreatedAt { get; set; }
        public string? SpecialRequest {  get; set; }
        public bool IsPayed { get; set; }
        public DateTime? PayedAt { get; set; }

        public IdentityUser? User { get; set; }

    }
}
