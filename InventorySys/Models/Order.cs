using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySys.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; } = new AppUser();
         public List <OrderItem> orderItems { get; set; } = new List<OrderItem>();
        public bool isCompleted{set;get;}
    }
}