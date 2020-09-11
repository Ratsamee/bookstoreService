using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace bookstoreService.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BaseController : ControllerBase
    {
        protected string ConnectionString = "";
        public BaseController(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("devConnection");
        }
    }
}