﻿using Microsoft.AspNetCore.Mvc;

namespace Booking
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult blog_grid()
        {
            return View();
        }
        public IActionResult blog_masonry()
        {
            return View();
        }
    }
}
