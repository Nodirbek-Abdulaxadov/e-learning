using Microsoft.AspNetCore.Mvc;

namespace E_Learning.API.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
