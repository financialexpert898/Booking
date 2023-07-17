using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? OtherDetails { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
