using AutoMapper;
using CheckOn.Business.Objects.Auth;
using CheckOn.WebApp.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOn.WebApp.Profiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<UserModel, UserAccountBO>();
        }
    }
}
