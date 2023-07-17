using Microsoft.AspNetCore.Mvc;

namespace Booking
{
    public class PagesController : Controller
    {
        public IActionResult my_booking()
        {
            return View();
        }
        public IActionResult testimonial()
        {
            return View();
        }
        public IActionResult restaurant()
        {
            return View();
        }
    }
}
