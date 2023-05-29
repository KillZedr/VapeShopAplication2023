using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;

namespace VSA.ServicesInterfaces
{
    public interface IUserServise
    {
        Task<User> AddUserAsync(string email, string password, string name);
        Task<User[]> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task DeleteUserAsync(int userId);
        Task<User> UpdateUserAsync(User user);
    }
}
