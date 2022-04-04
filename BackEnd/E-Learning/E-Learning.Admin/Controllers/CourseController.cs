using E_Learning.Admin.Services;
using E_Learning.BL.Interfaces;
using E_Learning.Domain;
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
        private IFileUploadInterface _fileInterface;

        public CourseController(ICourseInterface courseInterface,
                                ISectionInterface themeInterface,
                                IFileUploadInterface fileInterface)
        {
            _courseInterface = courseInterface;
            _sectionInterface = themeInterface;
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
                Sections = await _sectionInterface.GetSections()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCourseViewModel viewModel)
        {
            viewModel.Course.Id = Guid.NewGuid();
            foreach (var file in viewModel.Files)
            {
                var fileModel = _fileInterface.UploadFile(file);
                fileModel.KursId = viewModel.Course.Id;
            }

            await _courseInterface.AddCourse(viewModel.Course);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            _courseInterface.RemoveCourse(id);
            return RedirectToAction("Index");
        }
    }
}
