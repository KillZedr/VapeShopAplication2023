using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;

namespace VSA.DomainServicesInterfaces
{
    public interface IProductRepository
    {
        Task<Product[]> GetAllProductAsync();
        Task<Product> GetProductAsync(int productId);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);

        Task<Product> GetProductByName(string productName);


    }
}
