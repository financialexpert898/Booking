using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class RoomType
    {
        public int RoomTypeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
