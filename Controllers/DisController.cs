using asp_empty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace asp_empty.Controllers
{
    [ApiController]
    public class DisController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public DisController(IDistributedCache cache)
        {
            _cache = cache;
        }
        [HttpGet("/dis/{age}")]
        public async Task<IActionResult> GetUserById(int age)
        {
            User? user = null;
            string dataSource = "";

            var userString = await _cache.GetStringAsync(age.ToString());

            if (userString != null)
            {
                user = JsonConvert.DeserializeObject<User>(userString);
                dataSource = "Cache"; 
                Console.WriteLine($"{user?.Username} извлечен из кэша");
            }
            else
            {
                user = GetUserDataFromDatabase(age);

                if (user != null)
                {
                    dataSource = "Database";    
                    Console.WriteLine($"{user.Username} извлечен из базы данных");

                    userString = JsonConvert.SerializeObject(user);
                    await _cache.SetStringAsync(age.ToString(), userString, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                    });
                }
            }

            // Создаем объект AnonymousType для объединения данных пользователя и информации о происхождении в один JSON-объект
            var response = new
            {
                User = user,
                DataSource = dataSource
            };

            return Ok(response);
        }

        private User GetUserDataFromDatabase(int age)
        {
            return new User { Username = "John", Age = age  };
        }
    }
}
