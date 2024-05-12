using asp_empty.data;
using asp_empty.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace asp_empty.Controllers
{

    [ApiController]
    public class MainController : Controller
    {

        private DBcontext db;
        public MainController(DBcontext db)
        {
            this.db = db;
        }



        [HttpGet("/user/{id}")]
        public IActionResult GetuserById(int id)
        {
            string DataForm = "default value";

            User? user = DataProxy.GetUserById(id);

            if(user == null)
            {
                user  = db.Users.FirstOrDefault(i => i.Age == id);
                if(user != null )
                {
                    DataForm = "fromDatabase";
                    DataProxy.SetUser(user);

                }
                else
                {
                    DataForm = "fromcacahe";
                }

            }



            return Json(new { User = user, dataform = DataForm });
        }


        

    }
}
