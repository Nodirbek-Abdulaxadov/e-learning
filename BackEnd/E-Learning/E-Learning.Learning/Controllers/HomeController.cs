using E_Learning.BL.Interfaces;
using E_Learning.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChapterInterface _chapterInterFace;
        private readonly ICourseInterface _courseInterface;
        private readonly ISectionInterface _sectionInterface;

        public HomeController(  ILogger<HomeController> logger,
                                IChapterInterface chapterInterFace,
                                ICourseInterface courseInterface,
                                ISectionInterface sectionInterface)
        {
            _chapterInterFace = chapterInterFace;
            _courseInterface = courseInterface;
            _sectionInterface = sectionInterface;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Chapter(string courseName)
        {
            var section = _sectionInterface.GetSections().Result.FirstOrDefault(s => s.Name == courseName);
            var theme = await _courseInterface.GetCourses(section.Id);
            var chapters = await _chapterInterFace.GetChapter(section.ChapterId);
            IndexViewModel viewModel = new IndexViewModel()
            {
                Chapter = chapters,
                Courses = theme
            };
            return View(viewModel);
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Courses(Guid id)
        {
            var course = await _courseInterface.GetCourse(id);
            IndexViewModel viewModel = new IndexViewModel()
            { 
                Course = course
            };
            return View(viewModel);
        }

        public IActionResult Word()
        {
            return View();
        }

        public async Task<IActionResult> Themes(string courseName)
        {
            var section = _sectionInterface.GetSections().Result.FirstOrDefault(s => s.Name == courseName);
            var theme = await _courseInterface.GetCourses(section.Id);
            var chapters = await _chapterInterFace.GetChapter(section.ChapterId);
            IndexViewModel viewModel = new IndexViewModel()
            {
                Chapter = chapters,
                Courses = theme
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Themes2(Guid id)
        {
            var theme = await _courseInterface.GetCourses(id);
            IndexViewModel viewModel = new IndexViewModel()
            {
                Courses = theme
            };
            return View("Themes", viewModel);
        }
    }
}
