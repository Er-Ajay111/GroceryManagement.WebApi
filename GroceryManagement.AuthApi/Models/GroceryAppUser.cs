using Microsoft.AspNetCore.Identity;

namespace GroceryManagement.AuthApi.Models
{
    public class GroceryAppUser:IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
    }
}
