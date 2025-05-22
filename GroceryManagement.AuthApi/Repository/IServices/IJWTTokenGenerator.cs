using GroceryManagement.AuthApi.Models;

namespace GroceryManagement.AuthApi.Repository.IServices
{
    public interface IJWTTokenGenerator
    {
        string GenerateJWTTokenAsync(GroceryAppUser appUser, IList<string> roles);
    }
}
