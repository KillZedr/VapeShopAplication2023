
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.ServicesInterfaces.DTOs;

namespace VSA.ServicesInterfaces
{
    public interface ICategoryService
    {
        Task<Category[]> GetAllCategoryAsync();
        Task<Category> GetCategoryAsync(int id);
        Task<Category> AddCategoryAsync(CreateCategoryDto category);
        Task<Category> UpdateCategoryAsync(int idCategory, EditCategoryDto category);
        Task DeleteCategoryAsync(int categoryId);
       
        /*Task<Product[]> GetAllCategoryProductAsync(string categoryProduct);
Task<List<Product>> GetCategoryProductAsync(string productName);*/
    }
}
