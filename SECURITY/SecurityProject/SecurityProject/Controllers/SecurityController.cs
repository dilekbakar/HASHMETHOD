using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;



namespace SecurityProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly IDataProtector _dataProtector;
        public SecurityController(IDataProtectionProvider dataprovider)
        {
            this._dataProtector = dataprovider.CreateProtector("This is the secret key to encrypt and decrypt");
        }

        [HttpGet]
        public IActionResult Index()
        {
            string plainText = "Hash Data";
            string encryptText = this._dataProtector.Protect(plainText);
            string decryptText = this._dataProtector.Unprotect(encryptText);
            return Ok(new { plainText, encryptText, decryptText });


        }
    }
}
