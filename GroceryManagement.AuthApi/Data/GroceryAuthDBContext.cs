using GroceryManagement.AuthApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagement.AuthApi.Data
{
    public class GroceryAuthDBContext:IdentityDbContext<GroceryAppUser>
    {
        public GroceryAuthDBContext(DbContextOptions<GroceryAuthDBContext> options):base(options)
        {

        }
        public DbSet<GroceryAppUser> GroceryAppUsers { get; set; }
    }
}
