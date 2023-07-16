using Microsoft.AspNetCore.Mvc;

namespace Booking
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
