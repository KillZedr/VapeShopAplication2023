using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.InfrastructureInterfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string email);
        Task<User> AddUserAsync(User user);
    }
}
