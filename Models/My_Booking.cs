using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class My_Booking
    {
        public My_Booking()
        {
            Payments = new HashSet<Payment>();
        }

      
        public string UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public string? OtherDetails { get; set; }

        public virtual IdentityUser User { get; set; } // Thêm thuộc tính User kiểu IdentityUser
        public virtual Room? Room { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
