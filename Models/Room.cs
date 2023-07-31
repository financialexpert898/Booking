using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<My_Booking>();
            Amenities = new HashSet<Amenity>();
        }

        public int RoomId { get; set; }

        public int? RoomTypeId { get; set; }
        public int? HotelId { get; set; }
        public int? status { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? OtherDetails { get; set; }
        public string? Img { get; set; }
        public virtual Hotel? Hotel { get; set; }
        public virtual ICollection<My_Booking> Bookings { get; set; }

        public virtual ICollection<Amenity> Amenities { get; set; }
        public virtual RoomType? RoomType { get; set; }
    }
}
