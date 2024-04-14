using asp_empty.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IdentityModel.Tokens.Jwt;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using asp_empty.data;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize<T>(value));
    }

    public static T? Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
    }
}
namespace asp_empty
{
    public class Program
    {
        public static void Main(string[] args)
        {



            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //настройка 
            builder.Services.AddAuthentication().AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
            });


            builder.Services.AddDistributedMemoryCache();// добавляем IDistributedMemoryCache
            builder.Services.AddSession();  // добавляем сервисы сессии

            var app = builder.Build();

            app.UseSession();   // добавляем middleware для работы с сессиями


            app.MapControllers();

            builder.Configuration.AddXmlFile("config.xml");

 
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            /*  app.UseStaticFiles();
              app.UseDirectoryBrowser();
              app.UseAuthentication();
              app.UseAuthorization();*/




            app.Map("/", (IConfiguration appConfig) => $"{appConfig["person"]} - {appConfig["company"]}");



            app.Run();
        }

        class Person
        {
            public string Name { get; set; } = "";
            public int Age { get; set; }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Program>();
            })
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            });
        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer"; // Издатель токена
            public const string AUDIENCE = "MyAuthClient"; // Потребитель токена
            const string KEY = "mysupersecret_secretsecretsecretkey!123";   // Ключ для шифрации

            public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }

















    }
}
