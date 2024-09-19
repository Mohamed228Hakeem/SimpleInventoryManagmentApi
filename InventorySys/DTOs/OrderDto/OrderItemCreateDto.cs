using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySys.DTOs.OrderDto
{
    public class OrderItemCreateDto
    {
         public int ProductId { get; set; }
         public int Quantity { get; set; }
    }
}