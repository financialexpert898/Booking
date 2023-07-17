using Microsoft.AspNetCore.Mvc;

namespace Booking
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
