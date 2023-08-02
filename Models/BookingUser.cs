using Microsoft.AspNetCore.Identity;

namespace Booking.Models
{
    public partial class BookingUser:IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
