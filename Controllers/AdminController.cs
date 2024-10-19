/*
using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: /Admin/Index
        [HttpGet]
        public IActionResult Index()
        {
            // Retrieve username from TempData and pass it to the view using ViewBag
            ViewBag.UserName = TempData["UserName"];
            return View();
        }

        // GET: /Admin/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            // Clear TempData or any session data if necessary
            TempData.Clear();

            // Redirect to the login page
            return RedirectToAction("Login", "User");
        }

    }
}
*/

using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System.Linq;

namespace mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserDbContext _context;

        public AdminController(UserDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Dashboard
        public IActionResult Index()
        {
            // Retrieve all users where IsActive is false (0)
            var inactiveUsers = _context.Users.Where(u => !u.IsActive).ToList();
            return View(inactiveUsers);
        }

        // POST: /Admin/AcceptUser
        [HttpPost]
        public IActionResult AcceptUser([FromBody] User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                existingUser.IsActive = true; // Set user to active
                _context.SaveChanges();
                return Ok(); // Return a success status
            }
            return NotFound(); // Return a not found status if user doesn't exist
        }

        [HttpPost]
        public IActionResult RejectUser([FromBody] User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser); // Remove user or handle rejection logic
                _context.SaveChanges();
                return Ok(); // Return a success status
            }
            return NotFound(); // Return a not found status if user doesn't exist
        }

    }
}
