using GroceryManagement.AuthApi.Models;
using GroceryManagement.AuthApi.Models.Dtos;

namespace GroceryManagement.AuthApi.Repository.IServices
{
    public interface IAuthService
    {
        Task<string> RegistrationAsync(RegistrationDto registrationDto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
        Task<bool> AssignRolesToUser(string EmailId ,IList<string> roles);
        Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto);
        Task<string> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
