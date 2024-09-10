using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.DTOs.CategoryDtos;
using InventorySys.Models;

namespace InventorySys.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToCategoryDto(this Category category)
        {
            return new CategoryDTO 
            {
                CategoryId = category.Id,
                Name = category.Name,
                Products = category.Products.Select(p => p.MapProductToDTO()).ToList()
                
                
            };
        }

        public static Category ToCategory(this CategoryDTO categoryDto)
        {
            return new Category
            {
                Id = categoryDto.CategoryId,
                Name = categoryDto.Name,
            };
        }
    }
}