using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.DB.Models
{
    public class Customers : GroceryBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        //public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
