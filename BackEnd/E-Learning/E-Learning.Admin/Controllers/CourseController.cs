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
        private readonly IFileInterface _filemodelservice;

        public CourseController(ICourseInterface courseInterface,
                                ISectionInterface themeInterface,
                                IFileUploadInterface fileInterface,
                                IFileInterface filemodelservice
                                )
        {
            _courseInterface = courseInterface;
            _sectionInterface = themeInterface;
            _fileInterface = fileInterface;
            _filemodelservice = filemodelservice;
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
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _courseInterface.GetCourse(id);

            EditCourseViewModel editCourse = new EditCourseViewModel()
            {
                Course = item,
                Sections = await _sectionInterface.GetSections(),
                Sources = _filemodelservice.GetFiles(item.Id)
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

        public IActionResult DeleteFile(Guid id)
        {
            var file = _filemodelservice.GetFile(id);
            Guid courseId = file.KursId;
            _filemodelservice.DeleteFile(file);
            return RedirectToAction("Edit", courseId);
        }

        public IActionResult Delete(Guid id)
        {
            _courseInterface.RemoveCourse(id);
            return RedirectToAction("Index");
        }
    }
}
