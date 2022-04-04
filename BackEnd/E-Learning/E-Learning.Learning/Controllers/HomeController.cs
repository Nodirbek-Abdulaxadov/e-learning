using E_Learning.BL.Interfaces;
using E_Learning.Learning.Models;
using E_Learning.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace E_Learning.Learning.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChapterInterface _chapterInterFace;
        private readonly ICourseInterface _courseInterface;
        private readonly IFileInterface _fileInterface;

        public HomeController(  ILogger<HomeController> logger,
                                IChapterInterface chapterInterFace,
                                ICourseInterface courseInterface,
                                IFileInterface fileInterface)
        {
            _chapterInterFace = chapterInterFace;
            _courseInterface = courseInterface;
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
        public async Task<IActionResult> Themes(Guid id)
        {
            var listOfThemes = await _courseInterface.GetCourses(id);
            IndexViewModel viewModel = new IndexViewModel()
            {
                Chapters = await _chapterInterFace.GetChaptersWithSections(),
                Courses = listOfThemes
            };
            return View(viewModel);
        }
    }
}
