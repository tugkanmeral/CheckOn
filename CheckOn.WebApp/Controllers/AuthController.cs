using CheckOn.Business.Abstract;
using CheckOn.Business.Objects.Auth;
using CheckOn.DataAccess.Entities;
using CheckOn.WebApp.Models.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Utils.HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthenticationService authenticationService;
        IUserAccountService userAccountService;

        public AuthController(IAuthenticationService authenticationService, IUserAccountService userAccountService)
        {
            this.authenticationService = authenticationService;
            this.userAccountService = userAccountService;
        }

        [HttpPost]
        public async Task<ResponseBase<UserAccountBO>> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return new ErrorResponse<UserAccountBO>("Tüm zorunlu alanları doldurun", StatusCodes.Status401Unauthorized);

            Task<UserAccountBO> userAccountTask = userAccountService.CheckUserAccount(model.Email, model.Password);
            UserAccountBO userAccount = await userAccountTask;

            if (userAccount == null)
                return new ErrorResponse<UserAccountBO>("Hatalı kullanıcı bilgileri", StatusCodes.Status401Unauthorized);

            userAccount.Token = authenticationService.Authenticate(userAccount);

            return new SuccessResponse<UserAccountBO>(userAccount);
        }
    }
}
