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
    public class UsersController : ControllerBase
    {
        IUserAccountService userAccountService;
        public UsersController(IUserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }
        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserModel user)
        {
            userAccountService.AddUserAccount(new UserAccountBO() { Email = user.Email, Password = user.Password, Role = UserRoleNames.USER });
        }
    }
}
