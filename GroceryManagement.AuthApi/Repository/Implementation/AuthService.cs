using GroceryManagement.AuthApi.Data;
using GroceryManagement.AuthApi.Models;
using GroceryManagement.AuthApi.Models.Dtos;
using GroceryManagement.AuthApi.Repository.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GroceryManagement.AuthApi.Repository.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly GroceryAuthDBContext _dBContext;
        private readonly UserManager<GroceryAppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJWTTokenGenerator _jwtTokenGenerator;

        public AuthService(GroceryAuthDBContext dBContext,UserManager<GroceryAppUser> userManager,RoleManager<IdentityRole> roleManager,IJWTTokenGenerator jwtTokenGenerator)
        {
            _dBContext = dBContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<bool> AssignRolesToUser(string EmailId , IList<string> roles)
        {
            try
            {
                var registeredUser = await _userManager.FindByEmailAsync(EmailId);
                if (registeredUser == null)
                {
                    throw new ArgumentException($"User not found with email : {EmailId}");
                }
                foreach(var role in roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(role));
                    }
                    await _userManager.AddToRoleAsync(registeredUser, role);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            try
            {
                if(loginDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null.");
                }
                var registeredUser = await _dBContext.GroceryAppUsers.FirstOrDefaultAsync(x => x.Email == loginDto.EmailId);
                if (registeredUser == null)
                {
                    throw new ArgumentException($"User not found with email : {loginDto.EmailId}");
                }
                var isValidPassword = await _userManager.CheckPasswordAsync(registeredUser, loginDto.Password);
                if (!isValidPassword)
                {
                    throw new ArgumentException("Invalid password");
                }
                var userDto = new AppUserDto
                {
                    Id = registeredUser.Id,
                    Name = registeredUser.FullName,
                    Email = registeredUser.Email,
                    Address = registeredUser.Address,
                    PinCode = registeredUser.PostalCode,
                    PhoneNo = registeredUser.PhoneNumber
                };
                var roles = await _userManager.GetRolesAsync(registeredUser);
                var loginResponse = new LoginResponseDto
                {
                    AppUser = userDto,
                    Token = _jwtTokenGenerator.GenerateJWTTokenAsync(registeredUser,roles), // Generate JWT token here
                    Message = "User Logged In Successfully"
                };
                return loginResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> RegistrationAsync(RegistrationDto registrationDto)
        {
            try
            {
                if(registrationDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null.");
                }
                var existingUser = await _dBContext.GroceryAppUsers.FirstOrDefaultAsync(x => x.Email == registrationDto.Email);
                if (existingUser != null)
                {
                    throw new ArgumentException($"User already exists with email : {registrationDto.Email}");
                }
                var newUser = new GroceryAppUser
                {
                    FullName = registrationDto.FullName,
                    UserName = registrationDto.Email,
                    Email = registrationDto.Email,
                    Address = registrationDto.Address,
                    PostalCode = registrationDto.PinCode,
                    PhoneNumber = registrationDto.MobileNumber
                };
                var result = await _userManager.CreateAsync(newUser, registrationDto.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("Registration failed due to weak password");
                }
                //assign roles to user
                if (registrationDto.Roles != null && registrationDto.Roles.Count > 0)
                {
                    await AssignRolesToUser(registrationDto.Email, registrationDto.Roles);
                }
                return "User Registered Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> ForgotPasswordAsync(ForgotPasswordDto forgotPasswordDto)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
                if (existingUser == null)
                {
                    throw new ArgumentException($"User not found with email : {forgotPasswordDto.Email}");
                }
                var token = await _userManager.GeneratePasswordResetTokenAsync(existingUser);
                //var resetLink = $"https://localhost:5001/reset-password?email={forgotPasswordDto.Email}&token={token}";
                // Send email with reset link (implementation not shown here)
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                if (resetPasswordDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null.");
                }
                var existingUser = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
                if (existingUser == null)
                {
                    throw new ArgumentException($"User not found with email : {resetPasswordDto.Email}");
                }
                var result = await _userManager.ResetPasswordAsync(existingUser, resetPasswordDto.Token, resetPasswordDto.NewPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Reset password failed");
                }
                return "Password Reset Successfully";                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
