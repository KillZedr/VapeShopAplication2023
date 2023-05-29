using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.DomainServicesInterfaces;

namespace VSA.DamainServices
{
    public class ProductRepository : IProductRepository
    {

        private readonly VapeShopContext _vapeShopContext;

        public ProductRepository(VapeShopContext vapeShopContext)
        {
            _vapeShopContext = vapeShopContext;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            _vapeShopContext.Products.Add(product); 
            await _vapeShopContext.SaveChangesAsync();

            return product;
        }

        public async Task DeleteProductAsync(Product product)
        {
            _vapeShopContext.Products.Remove(product);
            await _vapeShopContext.SaveChangesAsync();

        }

        public async Task<Product[]> GetAllProductAsync()
        {
            return await _vapeShopContext.Products.ToArrayAsync<Product>();
        }

        public async Task<Product> GetProductByName(string productName)
        {
            return await _vapeShopContext.Products.SingleOrDefaultAsync(p => p.ProductName == productName);
        }

        public Task<Product> GetProductAsync(int productId)
        {
            return _vapeShopContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId)!;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _vapeShopContext.Products.Update(product);
            await _vapeShopContext.SaveChangesAsync();
            return product;
           
        }
    }
}
