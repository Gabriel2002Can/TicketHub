using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPurchaseController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        // Constructor
        public TicketPurchaseController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Test - Get");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketPurchase ticket)
        {

            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];
            string? queueName = _configuration["QueueName"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            QueueClient queueClient = new QueueClient(connectionString,queueName);
            await queueClient.CreateIfNotExistsAsync(); 
            string message = JsonSerializer.Serialize(ticket);
            await queueClient.SendMessageAsync(message);

            return Ok(new { message = "Ticket purchase request received." });

        }

        

    }
}
