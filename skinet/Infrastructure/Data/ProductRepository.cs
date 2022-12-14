using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    #nullable disable
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductByIdAsync()
        {
           return await _context.Products.ToListAsync();
        }

        async Task<IReadOnlyList<ProductBrand>> IProductRepository.GetProductBrandsAsync()
        {
           return await _context.ProductsBrands.ToListAsync();
        }

        async Task<IReadOnlyList<Product>> IProductRepository.GetProductsAsync()
        {
           
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        async Task<IReadOnlyList<ProductType>> IProductRepository.GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}