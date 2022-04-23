using E_Learning.BL.Interfaces;
using E_Learning.ViewModel.ViewCourse;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace E_Learning.Admin.Controllers
{
    public class CourseController : Controller
    {
        private ICourseInterface _courseInterface;
        private readonly ISectionInterface _sectionInterface;

        public CourseController(ICourseInterface courseInterface,
                                ISectionInterface themeInterface
                                )
        {
            _courseInterface = courseInterface;
            _sectionInterface = themeInterface;
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
                Sections = await _sectionInterface.GetSections()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCourseViewModel viewModel)
        {
            viewModel.Course.Id = Guid.NewGuid();

            await _courseInterface.AddCourse(viewModel.Course);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _courseInterface.GetCourse(id);

            EditCourseViewModel editCourse = new EditCourseViewModel()
            {
                Course = item,
                Sections = await _sectionInterface.GetSections()
            };
            return View(editCourse);
        }

        //[HttpPost]
        //public IActionResult Edit(EditCourseViewModel viewModel)
        //{
        //    if (viewModel.Files.Count != 0)
        //    {

        //    }
        //}
        public IActionResult Delete(Guid id)
        {
            _courseInterface.RemoveCourse(id);
            return RedirectToAction("Index");
        }
    }
}
