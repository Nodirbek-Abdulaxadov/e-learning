using E_Learning.BL.Interfaces;
using E_Learning.Domain;
using E_Learning.ViewModel.ViewSection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace E_Learning.Admin.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionInterface _sectionInterface;

        public SectionController(ISectionInterface sectionInterface)
        {
            _sectionInterface = sectionInterface;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _sectionInterface.GetSections();
            return View(item);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddSectionViewModel viewModel)
        {
            Section section = new Section()
            {
                Id = Guid.NewGuid(),
                Name = viewModel.Name
            };

            await _sectionInterface.AddSection(section);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _sectionInterface.GetSection(id);
            return View((EditSectionViewModel)item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditSectionViewModel viewModel)
        {
            await _sectionInterface.UpdateSection((Section)viewModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            _sectionInterface.RemoveSection(id);
            return RedirectToAction("Index");
        }

    }
}
