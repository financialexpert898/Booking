using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Http;

namespace Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly bookingContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BookingController(bookingContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        //public void ConfigureServices(IServiceCollection services)
        //    {
        //        // Các dịch vụ khác

        //        services.AddIdentity<BookingUser, IdentityRole>()
        //                .AddEntityFrameworkStores<bookingContext>()
        //                .AddDefaultTokenProviders();

        //        // Các dịch vụ khác
        //    }


        public IActionResult MyBooking()
        {
            //var roomList = _context.Rooms.Select(x => new SelectListItem
            //{
            //    Value = x.RoomId.ToString(),
            //    Text = x.RoomTypeId.ToString(),
            //}).ToList();

            //var roomTypeList = _context.RoomTypes.Select(y => new SelectListItem
            //{
            //    Value = y.RoomTypeId.ToString(),
            //    Text = y.RoomTypeId.ToString(),
            //}).ToList();

            //var userNamesList = _context.BookingUsers.Select(z => new SelectListItem
            //{
            //    Value = z.Id.ToString(),
            //    Text = z.UserName.ToString(),
            //}).ToList();

            var bookingList = _context.Bookings.Select(a => new SelectListItem
            {
                Value = a.UserId.ToString(),

                Text = a.CheckOutDate.ToString(),
            }).ToList();


            ViewData["bookingList"] = bookingList.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MyBooking(My_Booking bk )
        {
            //var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
            bk.UserId = _userManager.GetUserId(User);
            _context.Bookings.Add(bk);
            _context.SaveChanges();
            return RedirectToAction("MyBooking");
            
        }
    }
}
