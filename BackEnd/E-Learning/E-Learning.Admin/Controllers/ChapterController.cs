using E_Learning.BL.Interfaces;
using E_Learning.Domain;
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
    }
}
