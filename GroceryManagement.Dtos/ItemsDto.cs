using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Dtos
{
    public class ItemsDto: GroceryBaseDto
    {
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Item Name can not be empty")]
        [StringLength(100, ErrorMessage = "Item Name can not be more than 100 characters")]
        public string ItemName { get; set; }
        public int CategoryId { get; set; }
    }
}
