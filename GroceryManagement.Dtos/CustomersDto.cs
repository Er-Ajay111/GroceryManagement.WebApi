using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Dtos
{
    public class CustomersDto: GroceryBaseDto
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Please enter your name here")]
        [StringLength(100,MinimumLength =3,ErrorMessage = "Name must be between 3 and 100 characters")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please enter your email here")]
        [EmailAddress(ErrorMessage = "Please enter a valid Email Id")]
        public string CustomerEmailId { get; set; }
        [Required(ErrorMessage = "Please enter your address here")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "Please enter your phone number here")]
        [RegularExpression(@"^\+91[6-9]\d{9}$",ErrorMessage ="Please enter a valid phone no")]
        public string CustomerPhoneNo { get; set; }
    }
}
