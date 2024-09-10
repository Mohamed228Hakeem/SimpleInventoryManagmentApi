using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.Models;

namespace InventorySys.DTOs
{
    public class ProductCreateDTO
    {
        
        public string Name {set;get;}
        public int Quantity {set;get;}
        public int Price {set;get;}
        public string Description {set;get;}
        public string Image {set;get;} = string.Empty;
         [Required]
         public int CategoryId {set;get;} = 1;

    }
}