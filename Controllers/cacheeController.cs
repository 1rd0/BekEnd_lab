using asp_empty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace asp_empty.Controllers
{
    public class CacheeController : Controller
    {
        private readonly IMemoryCache _cache;

        public CacheeController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet("/cachee/{age}")]
        public IActionResult GetUserById(int age)
        {
            User? user = null;
            string dataSource = "";

            if (!_cache.TryGetValue(age, out user))
            {
                user = GetUserDataFromDatabase(age);

                if (user != null)
                {
                    dataSource = "Database";
                    Console.WriteLine($"{user.Username} извлечен из базы данных");

                    // Кэшируем данные пользователя в памяти на 2 минуты
                    _cache.Set(age, user, TimeSpan.FromMinutes(2));
                }
            }
            else
            {
                dataSource = "MemoryCache";
                Console.WriteLine($"{user.Username} извлечен из кэша памяти");
            }

            var response = new
            {
                User = user,
                DataSource = dataSource
            };

            return Ok(response);
        }

        private User GetUserDataFromDatabase(int age)
        {
            // Замените этот метод на вашу логику извлечения данных пользователя из базы данных
            return new User { Username = "John", Age = age };
        }
    }
}
