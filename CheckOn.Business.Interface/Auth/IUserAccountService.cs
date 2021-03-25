using CheckOn.Business.Objects.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.Business.Abstract
{
    public interface IUserAccountService
    {
        UserAccountBO CheckUserAccount(string email, string password);
        void AddUserAccount(UserAccountBO userAccount);
    }
}
