using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
            Amenities = new HashSet<Amenity>();
        }

        public int RoomId { get; set; }
        public int? HotelId { get; set; }
        public string? RoomNumber { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? OtherDetails { get; set; }
        public int? Sophong { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Amenity> Amenities { get; set; }
    }
}
