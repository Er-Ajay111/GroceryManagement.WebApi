using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.DB.Models
{
    public class Stocks : GroceryBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }=DateTime.Now;             
        public string InvoiceNo { get; set; }
        public string DealerName { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Items Item { get; set; }
        public int Quantity { get; set; }
        public decimal CostPerQuantity { get; set; }
        public decimal TotalCost { get; set; }
    }
}
