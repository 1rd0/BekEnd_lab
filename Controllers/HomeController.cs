using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Collections.Generic;
namespace asp_empty.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    { 
        [HttpGet("html")]
        public IActionResult GetHtml()
        {
             return Content("<html><body><h1>Hello, world!</h1></body></html>", "text/html");
        }

        [HttpGet("json")]
        public IActionResult GetJson()
        {
             var data = new { Message = "Hello, world!" };
            return Ok(data);
        }

        [HttpGet("file")]
        public IActionResult GetFile()
        {
             var filePath = "D:/c#web/asp-empty/helloworld.txt";
            return PhysicalFile(filePath, "application/octet-stream");
        }
    }
    

     
}
