using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InventorySys.Models
{
    public class OrderItem
    {
    public int OrderItemId { get; set; }
    public int OrderId { get; set; } // Foreign key for Order
    public Order Order { get; set; } // Navigation property
    public int ProductId { get; set; } // Foreign key for Product
    public Product Product { get; set; } // Navigation property
    public int Quantity { get; set; }
    
    public decimal Price { get; set; } 
    
    }
}