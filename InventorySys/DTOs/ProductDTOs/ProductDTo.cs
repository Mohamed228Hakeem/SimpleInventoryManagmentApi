using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.DTOs.CategoryDtos;
using InventorySys.Models;

namespace InventorySys.DTOs
{
    public class ProductDTo
    {
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string? CategoryName { get; set; }
    }
}