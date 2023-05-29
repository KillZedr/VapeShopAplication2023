using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.DomainServicesInterfaces;
using VSA.ServicesInterfaces;
using VSA.ServicesInterfaces.DTOs;

namespace Aplication.product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddProductAsync(CreateProductDto product)
        {
            var newProduct = await _productRepository.GetProductByName(product.ProductName);
            if (newProduct != null) 
            {
                throw new Exception($"Продукт с таким именем уже есть {product.ProductName}");
            }
            newProduct = new Product() { ProductName = product.ProductName };
            newProduct = await _productRepository.AddProductAsync(newProduct);
            return newProduct;
        }

        public async Task DeleteProductAsync(int productId)
        {
            var deleteProduct = await GetProductAsync(productId);
            if (deleteProduct != null)
            {
                await _productRepository.DeleteProductAsync(deleteProduct);
            }
        }

        public async Task<Product[]> GetAllProductAsync()
        {
            return await _productRepository.GetAllProductAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            return await _productRepository.GetProductAsync(productId);
        }

       /* public async Task<List<Product>> GetProductByIdManufacturerAsync(int idManufacturer ,Product product)
        {
            var products= await GetAllProductAsync();
            var productByManufacturer = new List<Product>();
            if (products. == )


        }

        public async Task<List<Product>> GetProductsByPriceChanges(decimal fromThePrice, decimal upToThePrice)
        {
            var products = await GetAllProductAsync();
            var priceChangesProduct = new List<Product>();
            int countProductPriceChanges = 0;

            
            foreach (var product in products)
            {
                if (product.PriceChanges.Count >= fromThePrice || product.PriceChanges.Count <= upToThePrice)
                {
                    priceChangesProduct.Add(product);
                    countProductPriceChanges++;
                }
                
            }
            if (countProductPriceChanges == 0)
            {
                throw new Exception("Продуктов в таком ценовом диапазоне нет");
            }
            return priceChangesProduct;
        }
*/
        public async Task<Product> UpdateProductAsync(int productId, EditProductDto editProduct)
        {
            var updateProduct = await GetProductAsync(productId);
            if (updateProduct == null)
            {
                throw new Exception("Продукта с таким Id нет");
            }
            updateProduct.ProductName = editProduct.ProductName;
            return await _productRepository.UpdateProductAsync(updateProduct);    
        }
    }
}
