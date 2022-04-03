using E_Learning.BL.Interfaces;
using E_Learning.Domain;
using E_Learning.ViewModel.ViewCourse;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Learning.Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseInterface _courseInterface;
        private readonly IThemeInterface _themeInterface;
        private readonly IFileInterface _fileInterface;

        public CourseController(ICourseInterface courseInterface,
                                IThemeInterface themeInterface,
                                IFileInterface fileInterface)
        {
            _courseInterface = courseInterface;
            _themeInterface = themeInterface;
            _fileInterface = fileInterface;
        }
        public async Task<IActionResult> Index()
        {
            var listOfCourses = await _courseInterface.GetCourses();
            return View(listOfCourses);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddCourseViewModel viewModel = new AddCourseViewModel()
            {
                Themes = await _themeInterface.GetThemes()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCourseViewModel viewModel)
        {
            Course course = viewModel.Course;
            foreach (var file in viewModel.Files)
            {
                var fileModel = await _fileInterface.AddFile(file);
                fileModel.CourseId = course.Id;
                course.Sources.Add(fileModel);
            }

            await _courseInterface.AddCourse(course);

            return RedirectToAction("Index");
        }
    }
}
