using Microsoft.AspNetCore.Mvc;

namespace Booking
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			ViewData["Title"] = "Trang chu";
			return View();
		}
	}
}
