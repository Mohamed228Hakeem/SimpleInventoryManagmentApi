using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.Data;
using InventorySys.DTOs.CategoryDtos;
using InventorySys.Interfaces;
using InventorySys.Mapper;
using InventorySys.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySys.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context ;
        }

        public async Task AddCategoryAsync(String category)
        {
            var Newcat = new Category
            {
                Name = category
            };

            _context.Categories.Add(Newcat);
            await _context.SaveChangesAsync();
        }


        public  async Task<List<CategoryDTO>> GetAll()
        {
            var categories = await _context.Categories.Include(p => p.Products).ToListAsync();
            var categoryDto = categories.Select(p => p.ToCategoryDto()).ToList();
            
            return categoryDto;
            
        }
    }
}