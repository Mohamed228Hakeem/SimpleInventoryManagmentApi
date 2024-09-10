using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging;
using InventorySys.Interfaces;
using InventorySys.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventorySys.Controllers
{
    [ApiController]
    [Route("api/CategoryManagment")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _CategoryRepo;
        
        public CategoryController(ICategoryRepo CategoryRepo)
        {
            _CategoryRepo = CategoryRepo;
            
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAll()
        {
            var Categories = await _CategoryRepo.GetAll();
            return Ok(Categories);
            
            
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return BadRequest("Category Name is required");
            }

            await _CategoryRepo.AddCategoryAsync(category);
            return Ok(new {
                MessageContent = $"Category Called '{category}'Added Successfully",
            });
        }

        
    }
}