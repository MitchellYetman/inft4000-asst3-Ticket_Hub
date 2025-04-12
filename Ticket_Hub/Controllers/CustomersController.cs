using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using System.Text;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from customers controller");
        }

        [HttpPost]
        public async Task<IActionResult> SendCustomerDataToAzureAsync (Purchase purchaseRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string queueName = "tickethub";
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered with the connection string");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            string message = JsonSerializer.Serialize(purchaseRequest);

            var plainTextBytes = Encoding.UTF8.GetBytes(message);
            await queueClient.SendMessageAsync(Convert.ToBase64String(plainTextBytes));

            return Ok("Purchase for " + purchaseRequest.Name + " successfully posted to Azure");

        }
    }
}
