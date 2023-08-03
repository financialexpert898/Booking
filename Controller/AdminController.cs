using Booking.Data;
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

        public IActionResult Adminstrator()
        {
            var book = _context.Bookings.Include(x=>x.Room).Include(x=>x.User).ToList();
            return View(book);
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
