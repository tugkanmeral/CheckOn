using AutoMapper;
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
using System.Threading.Tasks;

namespace CheckOn.Business
{
    public class UserAccountManager : IUserAccountService
    {
        ICryptoService _cryptoService;
        IUserRepository _userRepository;
        IMapper _mapper;
        public UserAccountManager(ICryptoService cryptoService, IUserRepository userRepository, IMapper mapper)
        {
            _cryptoService = cryptoService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserAccountBO> CheckUserAccount(string email, string password)
        {
            var encryptedPassword = _cryptoService.Encrypt(password);
            Task<User> userTask = _userRepository.GetAsync(u => u.Email == email && u.Password == encryptedPassword);
            User user = await userTask;

            if (user != null)
                return _mapper.Map<UserAccountBO>(user);
            else
                return null;
        }

        public void AddUserAccount(UserAccountBO userAccount)
        {
            User user = _mapper.Map<User>(userAccount);
            user.RoleId = (int)UserRoles.USER;

            _userRepository.AddAsync(user);
        }

    }
}
