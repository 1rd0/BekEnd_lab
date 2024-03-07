using Microsoft.AspNetCore.Mvc;

namespace asp_empty.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class cors : Controller
    {

        [HttpGet("result")]

        public IActionResult getInfo()
        {
            return Ok("hi from indian");
        }

        [HttpGet("GetStudent!")]

        public IActionResult GetStudent()
        {
            return Json(new { name = "dima", age = 16 });
        }
    }
}
