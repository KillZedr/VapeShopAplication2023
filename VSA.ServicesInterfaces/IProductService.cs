using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.ServicesInterfaces.DTOs;

namespace VSA.ServicesInterfaces
{
    public interface IProductService
    {
        Task<Product[]> GetAllProductAsync();
        Task<Product> GetProductAsync(int productId);
        Task<Product> AddProductAsync(CreateProductDto product);
        Task<Product> UpdateProductAsync(int productId, EditProductDto editProduct);
        Task DeleteProductAsync(int productId);
        /*Task<List<Product>> GetProductByIdManufacturerAsync(int idManufacturer, Product product);
        Task<List<Product>> GetProductsByPriceChanges(decimal fromThePrice, decimal upToThePrice);*/

    }
}
