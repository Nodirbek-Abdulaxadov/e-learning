using E_Learning.BL.Interfaces;
using E_Learning.Learning.Models;
using E_Learning.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace E_Learning.Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChapterInterface _chapterInterFace;
        private readonly IFileInterface _fileInterface;

        public HomeController(ILogger<HomeController> logger,
                                IFileInterface fileInterface,
                                IChapterInterface chapterInterFace)
        {
            _chapterInterFace = chapterInterFace;
            _fileInterface = fileInterface;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IndexViewModel viewModel = new IndexViewModel()
            {
                Chapters = await _chapterInterFace.GetChaptersWithSections()
            };

            return View(viewModel);
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
