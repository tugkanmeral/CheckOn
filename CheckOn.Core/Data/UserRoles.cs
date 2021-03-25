using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOn.Core.Data
{
    public enum UserRoles
    {
        ADMIN = 1,
        CAFE = 2,
        USER = 3
    }

    public static class UserRoleNames
    {
        public const string ADMIN = "ADMIN";
        public const string CAFE = "CAFE";
        public const string USER = "USER";

        public static int GetRoleId(string roleName)
        {
            return roleName switch
            {
                "ADMIN" => (int)UserRoles.ADMIN,
                "CAFE" => (int)UserRoles.CAFE,
                "USER" => (int)UserRoles.USER,
                _ => (int)UserRoles.USER,
            };
        }

        public static string GetRoleName(int roleId)
        {
            return roleId switch
            {
                (int)UserRoles.ADMIN => "ADMIN",
                (int)UserRoles.CAFE => "CAFE",
                (int)UserRoles.USER => "USER",
                _ => "USER",
            };
        }

        public static string GetRoleName(UserRoles role)
        {
            return role switch
            {
                UserRoles.ADMIN => "ADMIN",
                UserRoles.CAFE => "CAFE",
                UserRoles.USER => "USER",
                _ => "USER",
            };
        }
    }

}
