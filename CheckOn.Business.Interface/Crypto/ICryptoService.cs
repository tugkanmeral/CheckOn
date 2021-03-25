using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.Business.Abstract
{
    public interface ICryptoService
    {
        string Encrypt(string value);
        string Decrypt(string encrytedValue);
    }
}
