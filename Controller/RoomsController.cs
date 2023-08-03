using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Booking
{
    public class RoomsController : Controller
    {
        private readonly bookingContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public RoomsController(bookingContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult our_rooms()
        {
            List<Room> rooms = _context.Rooms.ToList();
            return View(rooms);
        }
        public IActionResult single_room()
        {
           
            return View();
        }

        [Authorize (Roles = "Sales")]
        [HttpGet]
        public ActionResult Insert()
        {
            var roomTypes = _context.RoomTypes.ToList();

            // Đưa danh sách RoomTypes vào ViewBag
            ViewBag.RoomTypes = roomTypes;

            var hotel = _context.Hotels.ToList();
            ViewBag.Hotels = hotel;
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Room room, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string fileName = Path.GetFileName(imageFile.FileName);
                string webRootPath = _hostingEnvironment.WebRootPath;
                string filePath = Path.Combine(webRootPath, "img", "content", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }

                // Lưu tên ảnh vào thuộc tính ImageName của model Room
                room.Img = fileName;

                // Lưu lại thay đổi vào CSDL

            }
            if (ModelState.IsValid)
            {
                // Thêm phòng mới vào CSDL và lưu thay đổi
                
                
                _context.Rooms.Add(room);
                _context.SaveChanges();

                return RedirectToAction("our_rooms"); // Chuyển hướng về trang danh sách phòng sau khi thêm thành công
            }
            else
            {
                // In ra các lỗi kiểm tra hợp lệ
                
                
                    // In ra các thông báo lỗi của mỗi trường
                    foreach (var entry in ModelState.Values)
                    {
                        foreach (var error in entry.Errors)
                        {
                            // Do something with the error, like logging or displaying to the user
                            Console.WriteLine(error.ErrorMessage);
                        }
                    }
                
            }

            return View(room);
        }

    }
}
