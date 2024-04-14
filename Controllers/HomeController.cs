using asp_empty.data;
using Microsoft.AspNetCore.Mvc;
 
namespace asp_empty.Controllers
{
    [ApiController]
   
    public class HomeController : Controller
    {

        [HttpGet("users")]
        public IActionResult Users()
        {

            return Json(DataWorker.GetUsers());
        }
         
       
    }
}
