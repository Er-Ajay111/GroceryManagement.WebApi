
using GroceryManagement.AuthApi.Data;
using GroceryManagement.AuthApi.Models;
using GroceryManagement.AuthApi.Models.Dtos;
using GroceryManagement.AuthApi.Repository.Implementation;
using GroceryManagement.AuthApi.Repository.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagement.AuthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<GroceryAuthDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJWTTokenGenerator, JWTTokenGenerator>();
            builder.Services.AddIdentity<GroceryAppUser,IdentityRole>().AddEntityFrameworkStores<GroceryAuthDBContext>().AddDefaultTokenProviders();
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
