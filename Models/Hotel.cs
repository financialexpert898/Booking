using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            Rooms = new HashSet<Room>();
        }

        public int HotelId { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? OtherDetails { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
