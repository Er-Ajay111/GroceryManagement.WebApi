using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.DB.Models
{
    public class Orders : GroceryBase
    {
        [Key]
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customers Customer { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
