using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Payment
    {
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime Date { get; set; }
        public string? PaymentMethod { get; set; }
        public string? OtherDetails { get; set; }

        public virtual My_Booking Booking { get; set; }
    }
}
