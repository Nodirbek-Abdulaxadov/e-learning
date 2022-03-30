using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Admin.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
