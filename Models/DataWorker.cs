using Microsoft.EntityFrameworkCore;
using asp_empty.data;

namespace asp_empty.Models
{
    public class DataWorker 
    {
        public static List<User> GetUsers()
        {
            using (DBcontext db = new DBcontext())
            {
                return db.users.ToList();

            }
        }

        public static void AddNewUser(User us)
        {
            using(DBcontext db = new DBcontext())
            {
                db.users.Add(us);
                db.SaveChanges();
            }
        }

        public static User GetuserById(int ID)
        {
            using(DBcontext db = new DBcontext())
            {
                
                User us = db.users.First(u => u.id == ID); 
                return us;

            }

        }
    }

}