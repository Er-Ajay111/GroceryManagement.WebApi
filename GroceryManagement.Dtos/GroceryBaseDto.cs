using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryManagement.Dtos
{
    public class GroceryBaseDto
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }= DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }=DateTime.Now;
        public int? status { get; set; }
    }
}
