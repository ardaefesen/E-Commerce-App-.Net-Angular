using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Interfaces;

namespace API.Controllers
{   
    #nullable disable
   
    public class ProductsController: BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        
        private readonly IGenericRepository<ProductBrand> _productsBrandRepo;
        
        private readonly IGenericRepository<ProductType> _productsTypeRepo;
    
        public ProductsController (IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> 
        productTypeRepo)
        {
            _productsBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;
            _productsTypeRepo = productTypeRepo;
        }

        [HttpGet]

        public async  Task<ActionResult<List<Product>>> GetProducts(){
              var products = await  _productsRepo.ListAllAsync();
              return Ok(products);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id){
            
            return await _productsRepo.GetByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() {
            return Ok(await _productsBrandRepo.ListAllAsync());
        }

         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() {
            return Ok(await _productsTypeRepo.ListAllAsync());
        }

        
    }

    
}