using Aplication.Application.Helpers;
using Aplication.Application.InfrastructureInterfaces;
using Aplication.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VapeShopAplication;
using VapeShopAplication.entitiSQLDataBaseMyVapeShop;

namespace Aplication.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepositori;
        public UserService(IUserRepository userRepositori)
        {
            _userRepositori = userRepositori;
        }

        public async Task<User> AddUserAsync(string email, string password)
        {
            var existUser = _userRepositori.GetUserAsync(email);
            if (existUser != null)
            {
                throw new Exception($"Пользователь с таким майлом {email} уже есть");
            }
            var user = new User()
            {
                Email = email,
                HashPassvord = Encoding.UTF8.GetString(PasswordHasher.PBKDF2Hash(password))
            };

            return await _userRepositori.AddUserAsync(user);
        }
    }
}
