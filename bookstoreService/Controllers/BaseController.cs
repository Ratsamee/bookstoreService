using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace bookstoreService.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class BaseController : ControllerBase
    {
        protected string ConnectionString = "";
        protected IConfiguration _config;
        public BaseController(IConfiguration configuration)
        {
            this._config = configuration;
            this.ConnectionString = configuration.GetConnectionString("devConnection");
        }
    }
}