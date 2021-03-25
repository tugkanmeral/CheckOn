using CheckOn.Business.Objects.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheckOn.Business.Abstract
{
    public interface IUserAccountService
    {
        Task<UserAccountBO> CheckUserAccount(string email, string password);
        void AddUserAccount(UserAccountBO userAccount);
    }
}
