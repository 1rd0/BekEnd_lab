using Microsoft.AspNetCore.Mvc;

namespace asp_empty.Controllers
{
    [ApiController]
     
    public class dataController : Controller
    {
        [HttpGet("Getdata")]
        public IActionResult GetData() {

            return Ok("Hello from data");
                
                }

    }
}
