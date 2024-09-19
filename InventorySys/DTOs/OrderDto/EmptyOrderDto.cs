using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySys.DTOs.OrderDto
{
    public class EmptyOrderDto
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public bool isCompleted{set;get;}
        public decimal TotalPrice { get; set; }
        public string Message { get; set; }
    }
}