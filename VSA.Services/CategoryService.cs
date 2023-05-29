
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.DomainServicesInterfaces;
using VSA.ServicesInterfaces;
using VSA.ServicesInterfaces.DTOs;

namespace VSA.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> AddCategoryAsync(CreateCategoryDto category)
        {
            var newCategory =  await _categoryRepository.GetCategoryByName(category.Name);
            if (newCategory != null)
            {
                throw new Exception($"Категория с таким именем уже есть {category.Name}");
            }

            newCategory = new Category() { CategoryName = category.Name, Products = new List<Product>()};
            newCategory = await _categoryRepository.AddCategoryAsync(newCategory);
            return newCategory;
        }

        

        public async Task DeleteCategoryAsync(int categoryId)
        {

           
            var categoryDelete = await GetCategoryAsync(categoryId);
            if (categoryDelete != null)
            {
                await _categoryRepository.DeleteCategoryAsync(categoryDelete);
            }
            
           

        }

        public Task<Category[]> GetAllCategoryAsync()
        {
            return _categoryRepository.GetAllCategoryAsync();
        }

       /* public Task<Product[]> GetAllCategoryProductAsync()
        {
            return _categoryRepository.GetAllCategoryProductAsync();
        }*/

        public async Task<Category> GetCategoryAsync(int id)
        {
            //  return _categoryRepository.GetCategoryAsync(CategoryId);
            return await _categoryRepository.GetCategoryAsync(id);
        }

       /* public async Task<List<Product>> GetCategoryProductAsync(string productName)
        {
            var productByCategory = await _categoryRepository.GetAllCategoryProductAsync();
            
            var productsCategory = new List<Product>();
            int countProduct = 0;

            foreach (var product in productByCategory) 
            {
                if (product.ProductName == productName)
                {
                    productsCategory.Add(product);
                    countProduct++;
                }
            }
            if (countProduct == 0)
            {
                throw new Exception($"Продукции с таким именем{productName} нет");
            } 
            return productsCategory;
        }*/

        public async Task<Category> UpdateCategoryAsync(int idCategory, EditCategoryDto category)
        {
            var updateCategory = await _categoryRepository.GetCategoryAsync(idCategory);
            if (updateCategory == null)
            {
                throw new Exception("Такой категории не существует");
            }
            updateCategory.CategoryName = category.Name;
            return await _categoryRepository.UpdateCategoryAsync(updateCategory);
        }
    }
}
