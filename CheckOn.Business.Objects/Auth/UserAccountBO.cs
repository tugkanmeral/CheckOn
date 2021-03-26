using CheckOn.Core.Data;
using System;

namespace CheckOn.Business.Objects.Auth
{
    public class UserAccountBO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }
    }
}
