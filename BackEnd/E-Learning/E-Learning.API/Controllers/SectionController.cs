using E_Learning.BL.Interfaces;
using E_Learning.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionInterface _sectionInterface;

        public SectionController(ISectionInterface sectionInterface)
        {
            _sectionInterface = sectionInterface;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSections()
        {
            var sectionsList = await _sectionInterface.GetSections();
            return Ok(sectionsList);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddSection(Section section)
        {
            section = await _sectionInterface.AddSection(section);
            return Ok(section);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateSection(Section section)
        {
            section = await _sectionInterface.UpdateSection(section);
            return Ok(section);
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteSection(Guid id)
        {
            _sectionInterface.RemoveSection(id);
            return Ok();
        }
    }
}
