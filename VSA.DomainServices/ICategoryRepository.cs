
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;

namespace VSA.DomainServicesInterfaces
{
    public interface ICategoryRepository
    {
        Task<Category[]> GetAllCategoryAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
        Task<Category> GetCategoryByName(string categoryName);
        /*Task<Product[]> GetAllCategoryProductAsync();*/
        /* Task<Product> GetCategoryProductAsync(string productName);*/


    }
}
