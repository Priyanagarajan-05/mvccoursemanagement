using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: /Student/StudentDashboard
        public IActionResult Index()
        {
            return View();
        }
    }
}
