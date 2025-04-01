using Microsoft.AspNetCore.Mvc;
using Ticket_Hub.Models;

namespace Ticket_Hub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly IConfiguration _configuration;

        public CustomersController(ILogger<CustomersController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult SendCustomerDataToAzure (Purchase purchaseRequest)
        {
            if (ModelState.IsValid)
            {

                return Ok("Successful post for " + purchaseRequest.name);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
