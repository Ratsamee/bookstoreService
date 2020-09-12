using bookstoreService.Data;
using bookstoreService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace bookstoreService.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        public UsersController(IConfiguration configuration):base(configuration)
        {

        }

        // GET: api/Users
        [Route("api/[controller]/signin")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Get([FromBody] SignIn signIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userAccess = new UserAccess(this.ConnectionString);
            var user = await userAccess.GetUser(signIn.Email.ToLower(), signIn.Password.Trim());
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Users
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userAccess = new UserAccess(this.ConnectionString);
                var newUser = await userAccess.AddUser(user);
                return Ok(newUser);
            }
            catch (Exception)
            {
                throw new Exception("something went wrong");
            }
            
        }

    }
}
