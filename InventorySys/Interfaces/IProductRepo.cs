using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.DTOs;
using InventorySys.Helpers;
using InventorySys.Models;

namespace InventorySys.Interfaces
{
    public interface IProductRepo
    {
       public Task<List<ProductDTo>> GetAllProducts();
       public Task<Product> GetProductById(int id);
       public Task<Product> AddProduct(Product product);
        public Task<List<ProductDTo>> SearchProducts(QueryObject query);
        public Task<bool> AddCategoryToProduct(int productId, string CategoryName);
    }
}