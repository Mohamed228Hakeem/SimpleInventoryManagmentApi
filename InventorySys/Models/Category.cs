using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySys.Models
{

    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { set; get; }
         public List<Product> Products { get; set; }
        
    }
}