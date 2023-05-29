using PasswordHasher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VSA.Domain;
using VSA.DomainServicesInterfaces;
using VSA.ServicesInterfaces;
using System.Security.Cryptography;


namespace VSA.Services
{
    public class UserServise : IUserServise
    {
        private readonly IUserRepository _userRepositori;
        public UserServise(IUserRepository userRepositori)
        {
            _userRepositori = userRepositori;
        }

        public async Task<User> AddUserAsync(string email, string password, string name)
        {
            var existUser = _userRepositori.GetUserByEmail(email);
            if (existUser != null)
            {
                throw new Exception($"Пользователь с таким майлом {email} уже есть");
            }
            var user = new User()
            {
                Email = email,
                HashPassvord = Encoding.UTF8.GetString(PasswordHasher.PasswordHasher.PBKDF2Hash(password)),
                UserName = name
            };

            user = await _userRepositori.AddUserAsync(user);

            return user;
        }

        public async Task DeleteUserAsync(int userId)
        {
            var userDelete = await GetUserByIdAsync(userId);
            if (userDelete != null)
            {
                await _userRepositori.DeleteUserAsync(userDelete);
            }
        }

        public async Task<User[]> GetAllUsersAsync()
        {
            return await _userRepositori.GetAllUserAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userRepositori.GetUserAsync(userId);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var updateUser = await _userRepositori.GetUserByEmail(user.Email);
            if (updateUser == null)
            {
                throw new Exception($"Пользователя с таким Email: {user.Email} не существует");
            }
            updateUser.Email = user.Email;
            updateUser.HashPassvord = user.HashPassvord;
            updateUser.HashPassvord = Encoding.UTF8.GetString(PasswordHasher.PasswordHasher.PBKDF2Hash(updateUser.HashPassvord));
            updateUser.UserName = user.UserName;

            return await _userRepositori.UpdateUserAsync(updateUser);
        }
    }
}
