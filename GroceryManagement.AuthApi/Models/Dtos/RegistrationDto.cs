using System.ComponentModel.DataAnnotations;

namespace GroceryManagement.AuthApi.Models.Dtos
{
    public class RegistrationDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name must be under 100 characters.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long and include at least 1 uppercase, 1 lowercase, 1 digit, and 1 special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be 10 digits.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address should be under 200 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Pin code is required.")]
        [RegularExpression(@"^\d{5,6}$", ErrorMessage = "Postal code must be 5 or 6 digits.")]
        public int PinCode { get; set; }

        public List<string> Roles { get; set; }
    }
}
