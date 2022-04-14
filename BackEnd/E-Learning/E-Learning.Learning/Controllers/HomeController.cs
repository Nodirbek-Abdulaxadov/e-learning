using E_Learning.BL.Interfaces;
using E_Learning.Domain;
using E_Learning.Learning.Models;
using E_Learning.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChapterInterface _chapterInterFace;
        private readonly ICourseInterface _courseInterface;
        private readonly IFileInterface _fileInterface;
        private readonly ISectionInterface _sectionInterface;

        public HomeController(  ILogger<HomeController> logger,
                                IChapterInterface chapterInterFace,
                                ICourseInterface courseInterface,
                                IFileInterface fileInterface,
                                ISectionInterface sectionInterface)
        {
            _chapterInterFace = chapterInterFace;
            _courseInterface = courseInterface;
            _fileInterface = fileInterface;
            _sectionInterface = sectionInterface;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(string courseName)
        {
            IndexViewModel viewModel = new IndexViewModel()
            {
                Chapters = await _chapterInterFace.GetChaptersWithSections()
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Courses(Guid id)
        {
            var course = await _courseInterface.GetCourse(id);
            course.Sources.Clear();
            course.Sources = _fileInterface.GetFiles(id);
            IndexViewModel viewModel = new IndexViewModel()
            {
                Chapters = await _chapterInterFace.GetChaptersWithSections(),
                Course = course
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Themes(string courseName)
        {
            var section = _sectionInterface.GetSections().Result.FirstOrDefault(s => s.Name == courseName);
            var theme = await _courseInterface.GetCourses(section.Id);
            IndexViewModel viewModel = new IndexViewModel()
            {
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
