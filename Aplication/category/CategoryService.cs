using Aplication.Application.REPSERITER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            var newCategory = await _categoryRepository.AddCategoryAsync(new Category() { CategoryName = category.CategoryName, Products = category.Products });
            return newCategory;
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            var categoryDelete = await GetCategoryAsync(category.CategoryId);
            if (categoryDelete != null)
            {
                await _categoryRepository.DeleteCategoryAsync(categoryDelete);
            }
            else
            {
                throw new Exception($"Такой категории {categoryDelete} нет");
            }

        }

        public Task<Category[]> GetAllCategoryAsync()
        {
            return _categoryRepository.GetAllCategoryAsync();
        }

        public Task<Product[]> GetAllCategoryProductAsync()
        {
            return _categoryRepository.GetAllCategoryProductAsync();
        }

        public Task<Category> GetCategoryAsync(int CategoryId)
        {
            return _categoryRepository.GetCategoryAsync(CategoryId);
        }

        public async Task<List<Product>> GetCategoryProductAsync(string productName)
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
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            var updateCategory = await GetCategoryAsync(category.CategoryId);
            if (updateCategory != null)
            {
                updateCategory.CategoryName = category.CategoryName;
                updateCategory.Products = category.Products;
            }
            else 
            {
                throw new Exception($"Категории с таким  Id {category.CategoryId} нет"); 
            }
            return await _categoryRepository.UpdateCategoryAsync(updateCategory);
        }
    }
}
