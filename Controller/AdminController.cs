using Booking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking
{
    public class AdminController : Controller
    {
        private readonly bookingContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(bookingContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Adminstrator()
        {
            // Lấy dữ liệu từ bảng My_Booking và bao gồm thông tin Room và RoomType
            var bookings = _context.Bookings
                .Include(b => b.Room)
                    .ThenInclude(r => r.RoomType)
                .Include(b => b.User)
                .ToList();

            return View(bookings);
        }
            [HttpPost]
        public IActionResult Delete(int ed)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.RoomId == ed);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
            return RedirectToAction("Adminstrator");
        }
    }   
}
