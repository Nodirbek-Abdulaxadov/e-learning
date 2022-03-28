using Microsoft.AspNetCore.Mvc;

namespace E_Learning.API.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
