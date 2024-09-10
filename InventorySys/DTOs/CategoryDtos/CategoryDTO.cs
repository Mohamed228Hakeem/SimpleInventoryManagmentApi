using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.Models;

namespace InventorySys.DTOs.CategoryDtos
{
    public class CategoryDTO
    {
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<ProductDTo> Products { get; set; }
    }
}