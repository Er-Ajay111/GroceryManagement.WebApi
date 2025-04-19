using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryManagement.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagement.DB.Data
{
    public class GroceryDbContext:DbContext
    {
        public GroceryDbContext(DbContextOptions<GroceryDbContext> options):base(options)
        {

        }
        public DbSet<Category> Category_tbl { get; set; }
        public DbSet<Items> Items_tbl { get; set; }
        public DbSet<Stocks> Stocks_tbl { get; set; }
        public DbSet<Customers> Customers_tbl { get; set; }
        public DbSet<Orders> Orders_tbl { get; set; }
        public DbSet<OrderItems> OrderItems_tbl { get; set; }
    }
}
