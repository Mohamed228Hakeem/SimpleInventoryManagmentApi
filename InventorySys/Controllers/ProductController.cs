using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.DTOs;
using InventorySys.Helpers;
using InventorySys.Interfaces;
using InventorySys.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace InventorySys.Controllers
{
    [ApiController]
    [Route("api/ProductManagement")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _ProductRepo;

        public ProductController(IProductRepo ProductRepo)
        {
            _ProductRepo = ProductRepo;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           
                var Products = await _ProductRepo.GetAllProducts();
                return Ok(Products);
            
        }

         [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] QueryObject query)
        {
           
                var Products = await _ProductRepo.SearchProducts(query);
                return Ok(Products);
            
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody]ProductCreateDTO productDto)
        {

            var productModel = productDto.To_Product_From_CreateProductDTO();
            await _ProductRepo.AddProduct(productModel);
            return Ok(productModel.Map_Product_To_CreateDTO());
        }


        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int productId,string CategoryName)
        {
            var product = await _ProductRepo.AddCategoryToProduct(productId,CategoryName);
            return Ok();
        }
        
    }
}