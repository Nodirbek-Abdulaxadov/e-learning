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
        private readonly IChapterInterface _chapterInterface;

        public SectionController(ISectionInterface sectionInterface,
                                 IChapterInterface chapterInterface)
        {
            _sectionInterface = sectionInterface;
            _chapterInterface = chapterInterface;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _sectionInterface.GetSections();
            return View(item);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddSectionViewModel viewModel = new AddSectionViewModel()
            {
                Chapters = await _chapterInterface.GetChapters()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddSectionViewModel viewModel)
        {
            viewModel.Section.Id = Guid.NewGuid();
            await _sectionInterface.AddSection(viewModel.Section);

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
