using E_Learning.BL.Interfaces;
using E_Learning.Domain;
using E_Learning.ViewModel.ViewChapter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace E_Learning.Admin.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IChapterInterface _chapterInterface;

        public ChapterController(IChapterInterface chapterInterface)
        {
            _chapterInterface = chapterInterface;
        }
        public async Task<IActionResult> Index()
        {
            var listOfChapters = await _chapterInterface.GetChapters();
            return View(listOfChapters);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Chapter chapter)
        {
            chapter.Id = Guid.NewGuid();
            chapter.Sections = null;
            await _chapterInterface.AddChapter(chapter);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var item = await _chapterInterface.GetChapter(id);
            return View((EditChapterViewModel)item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditChapterViewModel viewModel)
        {
            var item = await _chapterInterface.UpdateChapter((Chapter)viewModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            _chapterInterface.RemoveChapter(id);
            return RedirectToAction("Index");
        }
    }
}
