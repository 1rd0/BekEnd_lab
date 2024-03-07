using Microsoft.AspNetCore.Mvc;
using asp_empty.Models;
namespace asp_empty.Controllers
{
    [ApiController]
    public class Dbcontroller : Controller
    {
        [HttpGet("users")] 
        public IActionResult Users() { 
        return Json(DataWorker.GetUsers());
        }

        [HttpPost("users")]
        public IActionResult AddUser(User user)
        {
            DataWorker.AddNewUser(user);
            return Ok("succes");
        }

        [HttpGet("user/{id}")]

        public IActionResult Getuser(int id)
        {
            return Json(DataWorker.GetuserById(id));

        }

    }
}
