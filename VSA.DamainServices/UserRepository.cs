using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.DamainServices;
using VSA.Domain;
using VSA.DomainServicesInterfaces;

namespace VSA.DamainServices
{
    public class UserRepository : IUserRepository
    {

        private readonly VapeShopContext _vapeShopContext;

        public UserRepository(VapeShopContext vapeShopContext)
        {
            _vapeShopContext = vapeShopContext;
        }


       

        public async Task<User> AddUserAsync(User user)
        {
            _vapeShopContext.Users.Add(user);
            await _vapeShopContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(User user)
        {
            _vapeShopContext.Remove(user);
            await _vapeShopContext.SaveChangesAsync();
        }

        public async Task<User[]> GetAllUserAsync()
        {
            return await _vapeShopContext.Users.ToArrayAsync();
        }

       

        public async Task<User> GetUserAsync(int userId)
        {
            return await _vapeShopContext.Users.SingleOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await _vapeShopContext.Users.SingleOrDefaultAsync(u => u.Email == userEmail);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _vapeShopContext.Users.Update(user);
            await _vapeShopContext.SaveChangesAsync();
            return user;
        }
    }
}
