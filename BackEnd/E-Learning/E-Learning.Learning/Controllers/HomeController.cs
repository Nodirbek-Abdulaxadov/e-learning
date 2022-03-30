using E_Learning.BL.Interfaces;
using E_Learning.Learning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace E_Learning.Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileInterface _fileInterface;

        public HomeController(ILogger<HomeController> logger,
                                IFileInterface fileInterface)
        {
            _fileInterface = fileInterface;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(FileUpload fileUpload)
        {
            var res = _fileInterface.AddFile(fileUpload.formFile);
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Themes()
        {
            return View();
        }
    }
}
