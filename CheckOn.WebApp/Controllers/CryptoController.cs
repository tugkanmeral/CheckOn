using CheckOn.Core.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Utils;
using Phoenix.Utils.DataSecurity;

namespace CheckOn.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoleNames.ADMIN)]
    public class CryptoController : ControllerBase
    {
        [HttpGet("encrypt")]
        public string Encrypt(CryptoModel model)
        {
            return Crypto.Encrypt(model.Decrypted, ConfigGetter.GetSectionFromJson("CryptoKey"));
        }

        [HttpGet("decrypt")]
        public string Decrypt(CryptoModel model)
        {
            return Crypto.Decrypt(model.Encrypted, ConfigGetter.GetSectionFromJson("CryptoKey"));
        }

        [HttpGet("hash")]
        public string Hashing(string value)
        {
            return Crypto.Sha256(value);
        }
    }

    public class CryptoModel
    {
        public string Encrypted { get; set; }
        public string Decrypted { get; set; }
    }
}
