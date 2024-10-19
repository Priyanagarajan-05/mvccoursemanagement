using Microsoft.AspNetCore.Mvc;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class CourseController : Controller
    {
        private readonly UserDbContext _context;

        public CourseController(UserDbContext context)
        {
            _context = context;
        }

        // GET: /Course/Create
        [HttpGet]
        public IActionResult CreateCourse()
        {
            return View();
        }

        // POST: /Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();
                return RedirectToAction("AddModule", new { courseId = course.CourseId });
            }

            return View(course);
        }

        // GET: /Course/AddModule
        [HttpGet]
        public IActionResult AddModule(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        // POST: /Course/AddModule
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddModule(Module module)
        {
            if (ModelState.IsValid)
            {
                _context.Modules.Add(module);
                _context.SaveChanges();
                return RedirectToAction("AddModule", new { courseId = module.CourseId }); // Redirect to add more modules if needed
            }

            return View(module);
        }
    }
}
