/*
using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        // GET: /User/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Ensure IsActive is set to false
                user.IsActive = false;

                _context.Users.Add(user);
                _context.SaveChanges();  // Save user to the database

                // Redirect to Login page after successful registration
                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        // GET: /User/Login (for reference)
        [HttpGet]
        public IActionResult Login()
        {
            return View();
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
    public class UserController : Controller
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        // GET: /User/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Ensure IsActive is set to false
                user.IsActive = false;

                _context.Users.Add(user);
                _context.SaveChanges();  // Save user to the database

                // Redirect to Login page after successful registration
                return RedirectToAction("Login", "User");
            }

            return View(user);
        }

        // GET: /User/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /*
         // POST: /User/Login
         [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult Login(string email, string password)
         {
             if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
             {
                 ViewBag.Error = "Email and Password are required.";
                 return View();
             }

             // Retrieve the user from the database based on email
             var user = _context.Users.FirstOrDefault(u => u.Email == email);

             if (user == null)
             {
                 ViewBag.Error = "Invalid login attempt.";
                 return View();
             }

             // Check if the account is active
             if (!user.IsActive)
             {
                 ViewBag.Error = "Your request is pending.";
                 return View();
             }

             // Verify the password
             if (user.Password != password)
             {
                 ViewBag.Error = "Invalid login attempt.";
                 return View();
             }

             // Redirect based on the role
             switch (user.Role)
             {
                 case "Admin":
                     return RedirectToAction("Index", "Admin");  // Redirect to Admin dashboard

                 case "Professor":
                     return RedirectToAction("Index", "Professor");  // Redirect to Professor dashboard

                 case "Student":
                     return RedirectToAction("Index", "Student");  // Redirect to Student dashboard

                 default:
                     ViewBag.Error = "Invalid role.";
                     return View();
             }
         }*/
        // In UserController
        // POST: /User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Email and Password are required.";
                return View();
            }

            // Retrieve the user from the database based on email and password
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Invalid login attempt.";
                return View();
            }

            // Set the user's name in TempData for the dashboard
            TempData["UserName"] = user.Name;

            // Redirect based on the role
            switch (user.Role)
            {
                case "Admin":
                    return RedirectToAction("Index", "Admin");

                case "Professor":
                    return RedirectToAction("Dashboard", "Professor");

                case "Student":
                    return RedirectToAction("Index", "Student");

                default:
                    ViewBag.Error = "Invalid role.";
                    return View();
            }
        }



        // POST: /User/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            // Add logic to clear user session or authentication tokens here

            return RedirectToAction("Login", "User");
        }



    }
}



/*

using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using mvc.Data;

namespace mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        // Register method remains as defined earlier

        // GET: /User/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Store the username and role in session
                HttpContext.Session.SetString("UserName", user.Name);
                HttpContext.Session.SetString("UserRole", user.Role);

                // Redirect based on role
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Role == "Professor")
                {
                    return RedirectToAction("Index", "Professor");
                }
                else if (user.Role == "Student")
                {
                    return RedirectToAction("Index", "Student");
                }
            }

            // If login fails, return to the login page
            ViewBag.Error = "Invalid login attempt";
            return View();
        }

        // GET: /User/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session on logout
            return RedirectToAction("Login");
        }

        // GET: User/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(new User());
        }

        // POST: User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Logic to save the user to the database goes here.
                // Redirect to login after successful registration.
                return RedirectToAction("Login", "User");
            }
            return View(model); // Return the view with the model to show validation errors if needed.
        }

    }
}

*/