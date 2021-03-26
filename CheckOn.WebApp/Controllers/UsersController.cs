using AutoMapper;
using CheckOn.Business.Abstract;
using CheckOn.Business.Objects.Auth;
using CheckOn.Core.Data;
using CheckOn.DataAccess.Entities;
using CheckOn.WebApp.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoleNames.ADMIN)]
    public class UsersController : ControllerBase
    {
        IUserAccountService _userAccountService;
        readonly IMapper _mapper;
        public UsersController(IUserAccountService userAccountService, IMapper mapper)
        {
            _userAccountService = userAccountService;
            _mapper = mapper;
        }

        [HttpPost]
        public void Post([FromBody] UserModel user)
        {
            UserAccountBO userAccount = _mapper.Map<UserAccountBO>(user);
            userAccount.Role = UserRoleNames.USER;
            _userAccountService.AddUserAccount(userAccount);
        }
    }
}
