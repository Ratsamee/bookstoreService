using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstoreService.Data;
using bookstoreService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace bookstoreService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(IConfiguration configuration) : base(configuration)
        {

        }

        // POST: api/Order
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var orderAccess = new OrderAccess(this.ConnectionString);
                var resut = await orderAccess.SaveOrder(order);
                return Ok(resut);
            }
            catch (Exception)
            {
                throw new Exception("something went wrong");
            }
        }
    }
}
