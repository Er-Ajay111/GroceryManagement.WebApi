using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Dtos
{
    public class CategoryDto:GroceryBaseDto
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Category Name can not be empty")]
        [StringLength(50, ErrorMessage = "Category Name can not be more than 100 characters")]
        public string CategoryName { get; set; }
    }
}
