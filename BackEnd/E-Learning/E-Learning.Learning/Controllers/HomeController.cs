using E_Learning.BL.Interfaces;
using E_Learning.Domain;
using E_Learning.Learning.Models;
using E_Learning.ViewModel;
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
        public async Task<IActionResult> Index(string courseName)
        {
            var coursesList = await _courseInterface.GetCourses();
            var course = coursesList.FirstOrDefault(c => c.Name == courseName)
                ?? coursesList[0];

            return RedirectToAction("Themes", course.Id);
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
            var Theme = await _courseInterface.GetCourses(id);
            IndexViewModel viewModel = new IndexViewModel()
            {
                Chapters = await _chapterInterFace.GetChaptersWithSections(),
                Courses = Theme
            };
            return View(viewModel);
        }
    }
}
