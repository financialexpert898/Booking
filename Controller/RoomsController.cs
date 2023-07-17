using Microsoft.AspNetCore.Mvc;

namespace Booking
{
	public class RoomsController : Controller
	{
		public IActionResult our_rooms ()
		{
			return View();
		}
		public IActionResult single_room()
		{
			return View();
		}

	}
}
