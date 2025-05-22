namespace GroceryManagement.AuthApi.Models.Dtos
{
    public class AppUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }
    }
}
