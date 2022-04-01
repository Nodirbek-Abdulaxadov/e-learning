using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Admin.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
