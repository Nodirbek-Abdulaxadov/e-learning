using E_Learning.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Learning.Learning.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly IFileInterface _fileInterface;

        public TestController(IFileInterface fileInterface)
        {
            _fileInterface = fileInterface;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> Get()
        {
            var fileList = await _fileInterface.GetFiles();
            return Ok(fileList);
        }
    }
}
