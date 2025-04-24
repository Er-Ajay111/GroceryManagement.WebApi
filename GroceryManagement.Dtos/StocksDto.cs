using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Dtos
{
    public class StocksDto: GroceryBaseDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Invoice date is required")]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        //[Required(ErrorMessage = "Invoice number is required")]
        //public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "Dealer name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Dealer name must be between 2 and 100 characters")]
        public string DealerName { get; set; }

        //[Required(ErrorMessage = "Category ID is required")]
        //public int CategoryId { get; set; }

        [Required(ErrorMessage = "Item ID is required")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Cost per quantity is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Cost per quantity must be greater than 0")]
        public decimal CostPerQuantity { get; set; }

        //[Required(ErrorMessage = "Total cost is required")]
        //[Range(0.01, double.MaxValue, ErrorMessage = "Total cost must be greater than 0")]
        //public decimal TotalCost { get; set; }
    }
}
