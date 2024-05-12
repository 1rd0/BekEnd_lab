using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laba18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestmetricController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRandomNumber()
        {
            int number = (new Random()).Next(1, 100);
            Task.Delay(1000);
            return Ok(number);
        }

        [HttpPost]
        public IActionResult GetResult()
        {
            return Ok(new {message = "Hello world"});
        }

        [HttpDelete]
        public IActionResult GetError(int id)
        {
            if (id == 1) throw new Exception();
            return BadRequest();
        }
    }
}
