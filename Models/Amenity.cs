using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Amenity
    {
        public Amenity()
        {
            Rooms = new HashSet<Room>();
        }

        public int AmenityId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
