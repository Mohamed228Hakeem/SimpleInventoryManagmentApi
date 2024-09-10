using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.DTOs.CategoryDtos;
using InventorySys.Models;

namespace InventorySys.Interfaces
{
    public interface ICategoryRepo
    {
        public  Task<List<CategoryDTO>> GetAll();
        public Task AddCategoryAsync(string categoryName);
    }
}