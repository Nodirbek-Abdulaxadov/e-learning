using E_Learning.BL.Interfaces;
using E_Learning.ViewModel.ViewCourse;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Learning.Admin.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseInterface _courseInterface;
        private readonly IThemeInterface _themeInterface;

        public CourseController(ICourseInterface courseInterface,
                                IThemeInterface themeInterface)
        {
            _courseInterface = courseInterface;
            _themeInterface = themeInterface;
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
    }
}
