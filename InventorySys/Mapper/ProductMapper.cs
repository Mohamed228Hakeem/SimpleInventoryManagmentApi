using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.DTOs;
using InventorySys.Models;

namespace InventorySys.Mapper
{
    public static class ProductMapper
    {
        public static ProductCreateDTO Map_Product_To_CreateDTO(this Product Model)
        {
            return new ProductCreateDTO
            {

                
                Name = Model.Name,
                Quantity = Model.Quantity,
                Price = Model.Price,
                Description = Model.Description,
                Image = Model.Image,
                CategoryId = Model.CategoryId,

            };
            
        }

        public static Product To_Product_From_CreateProductDTO(this ProductCreateDTO productDTO)
        {
            return new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Description = productDTO.Description,
                CategoryId = productDTO.CategoryId,
            };

        }

    public static ProductDTo MapProductToDTO(this Product model)
    {
        return new ProductDTo
        {
            ProductId = model.ProductId,
            Name = model.Name,
            Quantity = model.Quantity,
            Price = model.Price
            ,CategoryName = model.Category.Name,
        };
    }

    // Mapping from ProductDTO to Product
    public static Product ToProductFromDTO(this ProductDTo productDTO)
    {
        return new Product
        {
            ProductId = productDTO.ProductId,
            Name = productDTO.Name,
            Quantity = productDTO.Quantity,
            Price = productDTO.Price
        };
    }
    }
}