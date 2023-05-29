using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;

namespace VSA.DomainServicesInterfaces
{
    public interface IUserRepository
    {
        Task<User[]> GetAllUserAsync();
        Task<User> GetUserAsync(int userId);
        Task<User> AddUserAsync(User user);

        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User> GetUserByEmail(string userEmail);

    }
}
