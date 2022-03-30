using E_Learning.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    }
}
