using bookstoreService.Data;
using bookstoreService.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace bookstoreService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(IConfiguration configuration) : base(configuration)
        {
        }

        // GET: api/Login
        [HttpPost]
        public IActionResult Get([FromBody] SignIn signIn)
        {
            var loginAccess = new LoginAccess(_config);
            var token = loginAccess.GenerateJSONWebToken(signIn);
            return string.IsNullOrEmpty(token)? (IActionResult) Unauthorized(): Ok(new { jwt = token});
        }
        
    }
}
