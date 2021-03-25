using CheckOn.Business.Objects.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.Business.Abstract
{
    public interface IAuthenticationService
    {
        string Authenticate(UserAccountBO userAccount);
    }
}
