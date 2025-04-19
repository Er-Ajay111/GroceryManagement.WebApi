using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroceryManagement.Dtos
{
    public class OrderItemsDto: GroceryBaseDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
        [JsonIgnore]
        //[Required(ErrorMessage = "Cost per quantity is required")]
        //[Range(0.01, double.MaxValue, ErrorMessage = "Cost per quantity must be positive")]
        public decimal CostPerQuantity { get; set; }
        [JsonIgnore]

        //[Required(ErrorMessage = "Total cost is required")]
        //[Range(0.01, double.MaxValue, ErrorMessage = "Total cost must be positive")]
        public decimal TotalCost { get; set; }
    }
}
