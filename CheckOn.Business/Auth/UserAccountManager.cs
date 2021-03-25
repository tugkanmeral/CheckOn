using CheckOn.Business.Abstract;
using CheckOn.Business.Objects.Auth;
using CheckOn.Core.Data;
using CheckOn.DataAccess.Abstract;
using CheckOn.DataAccess.Entities;
using Microsoft.IdentityModel.Tokens;
using Phoenix.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CheckOn.Business
{
    public class UserAccountManager : IUserAccountService
    {
        ICryptoService cryptoService;
        IUserRepository userRepository;
        public UserAccountManager(ICryptoService cryptoService, IUserRepository userRepository)
        {
            this.cryptoService = cryptoService;
            this.userRepository = userRepository;
        }

        public UserAccountBO CheckUserAccount(string email, string password)
        {
            var encryptedEmail = cryptoService.Encrypt(email);
            var encryptedPassword = cryptoService.Encrypt(password);
            User user = userRepository.Get(u => u.Email == encryptedEmail && u.Password == encryptedPassword);

            if (user != null)
                return new UserAccountBO() { Email = user.Email, Role = UserRoleNames.GetRoleName(user.RoleId) };
            else
                return null;
        }

        public void AddUserAccount(UserAccountBO userAccount)
        {
            userRepository.Add(new User() { Email = cryptoService.Encrypt(userAccount.Email), Password = cryptoService.Encrypt(userAccount.Password), RoleId = (int)UserRoles.USER});
        }

    }
}
