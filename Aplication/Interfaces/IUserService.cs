using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUserAsync(string email, string password);

    }
}
