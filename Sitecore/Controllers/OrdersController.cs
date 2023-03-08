using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using Sitecore.Messaging.Services;
using System.Text;

namespace Sitecore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IRabbitMqService _rabbitMqService;

        public OrdersController(ILogger<OrdersController> logger, IRabbitMqService rabbitMqService)
        {
            _logger = logger;
            _rabbitMqService = rabbitMqService;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] string text)
        {
            using var connection = _rabbitMqService.CreateChannel();
            using var model = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(text);
            model.BasicPublish("OrderExchange",
                                 string.Empty,
                                 basicProperties: null,
                                 body: body);

            return Ok();
        }
    }
}