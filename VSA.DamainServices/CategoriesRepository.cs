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
    public class CategoriesRepository : ICategoryRepository
    {
        private readonly VapeShopContext _vapeShopContext;

        public CategoriesRepository(VapeShopContext vapeShopContext)
        {
            _vapeShopContext = vapeShopContext;
        }


        public async Task<Category> AddCategoryAsync(Category category)
        {
           
            _vapeShopContext.Categories.Add(category);
            await _vapeShopContext.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            
            _vapeShopContext.Categories.Remove(category);
            await _vapeShopContext.SaveChangesAsync();
        }

        public async Task<Category[]> GetAllCategoryAsync()
        {
            return await _vapeShopContext.Categories.ToArrayAsync();
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _vapeShopContext.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
            
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            
            _vapeShopContext.Categories.Update(category);
            await _vapeShopContext.SaveChangesAsync();
            return category;
        }
        public async Task<Category> GetCategoryByName(string categoryName)
        {
            return await _vapeShopContext.Categories.SingleOrDefaultAsync(c => c.CategoryName == categoryName);
        }
    }
}
