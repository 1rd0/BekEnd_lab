using asp_empty.Controllers;
using Microsoft.AspNetCore.Antiforgery;
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

            var builder = WebApplication.CreateBuilder();
            // добавляем сервисы CORS и определяем политики
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Option", builder => builder
                 .WithOrigins("http://localhost:5057")
                .WithMethods("GET")
                .WithHeaders("custom-header"));



            });
            var app = builder.Build();
            // настраиваем CORS
            app.UseCors("Option");
            app.Run(async (context) =>
            {
                 
                  await context.Response.WriteAsync("Answer!");
               
            });
            app.Run();
        }
         
         



    }
}