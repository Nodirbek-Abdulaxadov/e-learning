using E_Learning.BL.Interfaces;
using E_Learning.ViewModel.ViewTheme;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace E_Learning.Admin.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IThemeInterface _themeInterface;
        private readonly ISectionInterface _sectionInterface;

        public ThemeController(IThemeInterface themeInterface,
                                 ISectionInterface sectionInterface)
        {
            _themeInterface = themeInterface;
            _sectionInterface = sectionInterface;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _themeInterface.GetThemes();
            return View(item);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddThemeViewModel viewModel = new AddThemeViewModel()
            {
                Sections = await _sectionInterface.GetSections()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddThemeViewModel viewModel)
        {
            viewModel.Theme.Id = Guid.NewGuid();
            await _themeInterface.AddTheme(viewModel.Theme);

            return RedirectToAction("Index");
        }
    }
}
