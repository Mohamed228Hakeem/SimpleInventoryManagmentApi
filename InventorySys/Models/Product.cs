using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySys.Models
{
    [Table("Product")]
    public class Product
    {
        public int ProductId {set;get;}
        public string Name {set;get;}
        
        public int Quantity {set;get;}
        public int Price {set;get;}
        public string Description {set;get;}
        public string Image {set;get;} = string.Empty;

        // Foreign key for Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Navigation property

        

       
        
    }
}