using asp_empty.Models;

namespace asp_empty.data
{
    public class DataWorker
    {
 

        public static List<User> GetUsers() 
        {
            
            using(DBcontext db = new DBcontext())
            {

                return db.Users.ToList();
            }
     
        }

        public static void AddUser(User us)
        {

            using (DBcontext db = new DBcontext())
            {

                  db.Users.Add(us);
                db.SaveChanges();   
            }

        }

        public static  User GetUserById(int age)
        {

            using (DBcontext db = new DBcontext())
            {

                return db.Users.First(u => u.Age == age);
            }

        }
    }
}
