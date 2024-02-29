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
        public List<Car> Cars = new List<Car> {new Car("Porshe" , 230)};

        [HttpGet("Cars")]
        public IActionResult GetCars()
        {
            return Ok(Cars);
        }

        [HttpPut("EditCar")]
        public IActionResult EditCar(int id, Car car)
        {
            // Проверяем корректность id
            if (id > 0 && id < Cars.Count)
            {
                Cars[id].Name = car.Name;
                Cars[id].Speed = car.Speed;

                return Ok("Car updated successfully");
                
            }
            else
            {
                return NotFound("Car not found");
            }

              
        }

        [HttpPost("AddCar")]
        public IActionResult AddCar([FromBody] Car car)
        {
            Cars.Add(car);
            return Ok("Car added successfully");
        }

        [HttpDelete("RemoveCar/{id}")]
        public IActionResult RemoveCar(int id)
        {
            var carToRemove = Cars.Find(c => c.Id == id);
            if (carToRemove == null)
                return NotFound();

            Cars.Remove(carToRemove);
            return Ok("Car removed successfully");
        }
        [HttpGet("html")]
        public IActionResult GetHtml()
        {
            // Логика формирования HTML страницы
            return Content("<html><body><h1>Hello, world!</h1></body></html>", "text/html");
        }

        [HttpGet("json")]
        public IActionResult GetJson()
        {
            // Логика формирования JSON данных
            var data = new { Message = "Hello, world!" };
            return Ok(data);
        }

        [HttpGet("file")]
        public IActionResult GetFile()
        {
            // Логика возвращения файла
            var filePath = "D:/c#web/asp-empty/helloworld.txt";
            return PhysicalFile(filePath, "application/octet-stream");
        }
    }
    public class Car
    {
        private static int Count = 1;
        public int Id { get; }
        public string Name { get; set; }
        public int Speed { get; set; }

        public Car(string name, int speed)
        {
            Id = Count++;
            Name = name;
            Speed = speed;
        }
    }

     
}
