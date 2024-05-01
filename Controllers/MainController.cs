using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace asp_empty.Controllers
{

    [ApiController]
    public class MainController : Controller
    {
        [HttpGet("/dividezero/{a}/{b}")]
        public IActionResult Divide(int a,int b)
        {
            float res;
            try { res = a / b; }
            catch { return BadRequest("Деление на ноль недопустимо."); }
            return Ok(res);
        }


        [HttpGet("/any")]
        public IActionResult  NotFound()
        {
            return NotFound("Ресурс не найден.");
        }

    }
}
