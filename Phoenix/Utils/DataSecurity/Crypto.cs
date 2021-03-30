using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Phoenix.Utils.DataSecurity
{
    public static class Crypto
    {
        public static string Encrypt(string value, string key)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(value);
            using MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            using TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };

            ICryptoTransform transform = tripDes.CreateEncryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(results, 0, results.Length);
        }

        public static string Decrypt(string encrytedValue, string key)
        {
            byte[] data = Convert.FromBase64String(encrytedValue);
            using MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            using TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };

            ICryptoTransform transform = tripDes.CreateDecryptor();
            byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
            return UTF8Encoding.UTF8.GetString(results);
        }

        public static string Sha256(string rawData)
        {   
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
