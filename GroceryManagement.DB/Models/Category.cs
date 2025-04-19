using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.DB.Models
{
    public class Category: GroceryBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Items> Items { get; set; } = new List<Items>();
    }
}
