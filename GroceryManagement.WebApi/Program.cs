
using GroceryManagement.BL.Imlementation;
using GroceryManagement.BL.IServices;
using GroceryManagement.BL.Utility;
using GroceryManagement.DB.Data;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagement.WebApi
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
            builder.Services.AddDbContext<GroceryDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs"),
                sqlOptions=>sqlOptions.MigrationsAssembly("GroceryManagement.WebApi")));
            builder.Services.AddAutoMapper(typeof(GroceryMappingProfile));
            builder.Services.AddScoped<ICategoryService,CategoryService>();
            builder.Services.AddScoped<ICustomerService,CustomerService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IStockService, StockService>();
            builder.Services.AddScoped<IOrderService, OrderService>();

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
