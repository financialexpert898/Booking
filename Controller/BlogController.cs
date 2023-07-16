using Microsoft.AspNetCore.Mvc;

namespace Booking
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
