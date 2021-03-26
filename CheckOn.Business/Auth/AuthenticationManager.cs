using CheckOn.Business.Abstract;
using CheckOn.Business.Objects.Auth;
using CheckOn.Core.Data;
using Microsoft.IdentityModel.Tokens;
using Phoenix.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CheckOn.Business
{
    public class AuthenticationManager : IAuthenticationService
    {
        ICryptoService _cryptoService;
        public AuthenticationManager(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public string Authenticate(UserAccountBO userAccount)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigGetter.GetSectionFromJson("SecretKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userAccount.Email),
                    new Claim(ClaimTypes.Role, UserRoleNames.GetRoleName(userAccount.RoleId))
                }),
                Expires = DateTime.UtcNow.AddDays(Convert.ToInt32(ConfigGetter.GetSectionFromJson("TokenExpiresDay"))),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);

            return tokenStr;
        }
    }
}
