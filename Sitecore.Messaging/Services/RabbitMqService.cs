using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Sitecore.Messaging.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly RabbitMqConfig _rabbitMqConfig;

        public RabbitMqService(IOptions<RabbitMqConfig> rabbitMqConfig)
        {
            _rabbitMqConfig = rabbitMqConfig.Value;
        }

        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = _rabbitMqConfig.Username,
                Password = _rabbitMqConfig.Password,
                HostName = _rabbitMqConfig.Hostname,
                Port = _rabbitMqConfig.Port
            };
            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;
        }
    }
}
