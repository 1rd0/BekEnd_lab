using System.ComponentModel.DataAnnotations;

namespace asp_empty.Models
{
    public class User
    {
        public string Username { get; set; }
        public int Age { get; set; }

        public User(string name,int age)
        {
        this.Username = name;   
            this.Age = age;
        }
    }
}
