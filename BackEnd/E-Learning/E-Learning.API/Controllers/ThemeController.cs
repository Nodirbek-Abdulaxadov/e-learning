using E_Learning.BL.Interfaces;
using E_Learning.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace E_Learning.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ThemeController : Controller
    {
        private readonly IThemeInterface _themeInterface;

        public ThemeController(IThemeInterface themeInterface)
        {
            _themeInterface = themeInterface;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllThemes()
        {
            var themesList = await _themeInterface.GetThemes();
            return Ok(themesList);
        }


        /// <summary>
        /// Need ViewModels
        /// </summary>

        /*[HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddTheme(Theme theme)
        {
            theme = await _themeInterface.AddTheme(theme);
            return Ok(theme);
        }*/

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTheme(Theme theme)
        {
            theme = await _themeInterface.UpdateTheme(theme);
            return Ok(theme);
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteTheme(Guid id)
        {
            _themeInterface.RemoveTheme(id);
            return Ok();
        }
    }
}
