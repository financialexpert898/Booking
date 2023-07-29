using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Booking
{
    public class RoomsController : Controller
    {
        public IActionResult our_rooms()
        {
            var dbcontext = new bookingContext();
            List<Room> rooms = dbcontext.Rooms.ToList();
            return View(rooms);
        }
        public IActionResult single_room()
        {
            return View();
        }
        private readonly bookingContext dbContext = new bookingContext();

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Room room)
        {
            if (ModelState.IsValid)
            {
                // Thêm phòng mới vào CSDL và lưu thay đổi
                dbContext.Rooms.Add(room);
                dbContext.SaveChanges();
                return RedirectToAction("Index"); // Chuyển hướng về trang danh sách phòng sau khi thêm thành công
            }

            return View(room);

        }
    }
}
