using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.Messaging.Services;

namespace Sitecore.Messaging
{
    public static class MessagingExtension
    {
        public static void AddMessagingService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqConfig>(a => configuration.GetSection(nameof(RabbitMqConfig)).Bind(a));
            services.AddSingleton<IRabbitMqService, RabbitMqService>();
        }
    }
}
