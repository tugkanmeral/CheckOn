using CheckOn.Business.Abstract;
using CheckOn.Core.Data;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = UserRoleNames.ADMIN)]
    public class CryptoController : ControllerBase
    {
        ICryptoService _cryptoService;
        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        [HttpGet("encrypt")]
        public string Encrypt(CryptoModel model)
        {
            return _cryptoService.Encrypt(model.Decrypted);
        }

        [HttpGet("decrypt")]
        public string Decrypt(CryptoModel model)
        {
            return _cryptoService.Decrypt(model.Encrypted);
        }
    }

    public class CryptoModel
    {
        public string Encrypted { get; set; }
        public string Decrypted { get; set; }
    }
}
