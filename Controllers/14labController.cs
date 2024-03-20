using asp_empty.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static asp_empty.Program;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace asp_empty.Controllers
{
     
    

    [ApiController]
    [Route("[controller]")]
    public class _14labController : Controller
    {
        

        private readonly List<Person> people = new List<Person>
{
    new Person("dima", "123", new Role("admin")),
    new Person("artyr", "123", new Role("user")),
};


        [HttpPost("smt/foruser")]
        [Authorize(Roles = "user")]
        public IActionResult WriteSomething()
        {

            return Ok("good morning USER");
        }


        [HttpPost("login")]
        public IActionResult Login(Person loginData)
        {
            // Находим пользователя
            Person? person = people.FirstOrDefault(p => p.Email == loginData.Email && p.Password == loginData.Password);
            // Если пользователь не найден, отправляем статусный код 401
            if (person is null) return Unauthorized();

            var claims = new List<Claim>
{
    new Claim(ClaimTypes.Name, person.Email),
    new Claim(ClaimTypes.Role, person.Role.Name) // Добавление информации о роли в токен
};


             
            // Создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                username = person.Email,
                Role = person.Role
                
            };

            return Ok(response);
        }
        [HttpPost("data/access")]
        [Authorize]
        public IActionResult GetData()
        {
            return Ok( "U have access congrats" );
        }
        [HttpGet("AnyOne/{name:int}")]
        [AllowAnonymous]
        public IActionResult Anys(int name)
        {
            return Ok($"U have access AllowAnonymous {name}" );
        }

        [HttpPost("data/access/{name}")]
        [Authorize]
        public IActionResult GetData(string name)
        {
            // Теперь вы можете использовать параметр 'name' в вашей логике
            return Ok($"U have access, {name}! Congrats");
        }


    }

    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // Издатель токена
        public const string AUDIENCE = "MyAuthClient"; // Потребитель токена
        const string KEY = "mysupersecret_secretsecretsecretkey!123";   // Ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
    public record class Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        Role Standart = new Role("user");
        public Person() { }
        public Person(string email, string password, Role role)
        {
            Email = email;
            Password = password;
            Role = role;
        }
        public Person(string email, string password)
        {
            Email = email;
            Password = password;
            Role = Standart;
        }
    }
    public record class Role
    {
        public string Name { get; set; }
        public Role(string name) => Name = name;
    }
 }

 