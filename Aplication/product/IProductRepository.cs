using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.product
{
    public interface IProductRepository
    {
        Task<Product[]> GetAllProductAsync();
        Task<Product> GetProductAsync(int productId);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProducttAsync(int productId);

        
    }
}
