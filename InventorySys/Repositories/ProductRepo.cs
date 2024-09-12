using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.Data;
using InventorySys.DTOs;
using InventorySys.Helpers;
using InventorySys.Interfaces;
using InventorySys.Mapper;
using InventorySys.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySys.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {

            var Category = await _context.Categories.FindAsync(product.CategoryId);
            if (Category == null)
            {
                throw new Exception("Category not found");
            }
               
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
            return product;
                
          
        }

        public async Task<List<ProductDTo>> GetAllProducts()
        {
            

          var products = await _context.Products.Include(p=>p.Category).ToListAsync();

          var productsDto = products.Select(p => p.MapProductToDTO()).ToList();
          return productsDto;

        }

         public async Task<List<ProductDTo>> SearchProducts(QueryObject query)
        {
            
          var products = _context.Products.AsQueryable();

            if(string.IsNullOrEmpty(query.Category) 
            || query.Category.Equals("All",StringComparison.OrdinalIgnoreCase
            ))
            {
                products = products.Include(p=>p.Category);
            }    


            if (!string.IsNullOrEmpty(query.Category))
            {
                products = products
                .Include(p=>p.Category)
                .Where(p => p.Category.Name.ToLower() == query.Category.ToLower());
            }

            if(!string.IsNullOrEmpty(query.name))
            {
                products = products
                .Include(p=>p.Category)
                .Where(p => p.Name.ToLower().Contains(query.name.ToLower()));
            }
            //if name is null
             if(string.IsNullOrEmpty(query.name))
            {
                products = products.Include(p=>p.Category);
            }   


          var productsDto = products.Select(p => p.MapProductToDTO()).ToList();
          return productsDto;

        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddCategoryToProduct(int productId, string CategoryName)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product == null)
            return false;

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == CategoryName.ToLower());
            if (category == null)
            return false;

            product.CategoryId = category.Id;
            await  _context.SaveChangesAsync();

            return true;
        }


        
    }
}