using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Dtos
{
    public class OrdersDto: GroceryBaseDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "CustomerId is required")]
        public int CustomerId { get; set; }
        //public CustomersDto? CustomersDto { get; set; }
        [NotMapped]
        public ICollection<OrderItemsDto> OrderItemsDto { get; set; } = new List<OrderItemsDto>();
    }
}
