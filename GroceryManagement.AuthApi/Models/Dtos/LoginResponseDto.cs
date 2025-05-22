namespace GroceryManagement.AuthApi.Models.Dtos
{
    public class LoginResponseDto
    {
        public AppUserDto AppUser { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }= "User Logged In Successfully";
    }
}
