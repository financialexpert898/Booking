using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Booking
{
    public class AppRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        //List All the Role created by Users
        public IActionResult Index()
        {
            var role = _roleManager.Roles;
            
            return View(role);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model) {
            if(!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");

        }
    }
}
