using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;

namespace asp_empty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //ServiceCollection -    место, где вы 
            //    можете зарегистрировать 
            //    службы , которые будут 
            //    использоваться
            var container = new ServiceCollection();
            //регистрируете классы  Bird в контейнер служб 
            container.AddSingleton<IAnimal, Bird>();
            //создание поставщика служб 
            var serviceprovider = container.BuildServiceProvider();

            var Animal = serviceprovider.GetService<IAnimal>();

            var app = builder.Build();

            app.MapGet("/", () =>
            {
                Console.WriteLine($" Number of {Animal.Name()} legs: {Animal.CountOFLegs()}");
            });

            app.Run();
        }
        //сервис 
        public interface IAnimal
        {
            string Name();
            int CountOFLegs();
        }

        public class Dog : IAnimal
        {
            public string Name()
            {
                return "dog";
            }
            public int CountOFLegs()
            {
                return 4;
            }
        }

        public class Bird : IAnimal
        {
            public string Name()
            {
                return "Bird";
            }
            public int CountOFLegs()
            {
                return 2;
            }
        }
         


    }
}