using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;
using System.Linq;

namespace mvc.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly UserDbContext _context;

        public ProfessorController(UserDbContext context)
        {
            _context = context;
        }

        // GET: /Professor/Dashboard
        public IActionResult Dashboard()
        {
            ViewBag.UserName = TempData["UserName"]; // Retrieve the professor's name
            return View();
        }

        // GET: /Professor/CreateCourse
        public IActionResult CreateCourse()
        {
            return View();
        }

        // POST: /Professor/CreateCourse
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("AddModule", new { courseId = course.CourseId }); // Redirect to AddModule
            }

            return View(course);
        }

        // GET: /Professor/AddModule
        public IActionResult AddModule(int courseId)
        {
            ViewBag.CourseId = courseId; // Pass the Course ID to the view
            return View();
        }

        // POST: /Professor/AddModule
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddModule(int courseId, Module module)
        {
            if (ModelState.IsValid)
            {
                module.CourseId = courseId; // Link the module to the course
                _context.Modules.Add(module); // Add the module to the context
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("AddModule", new { courseId = courseId }); // Stay on the same page for more modules
            }

            return View(module);
        }

    }
}
