using RabbitMQ.Client;

namespace Sitecore.Messaging.Services
{
    public interface IRabbitMqService
    {
        IConnection CreateChannel();
    }
}
