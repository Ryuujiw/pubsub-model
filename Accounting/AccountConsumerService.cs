using Abc.Accounting.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Sitecore.Messaging.Services;

namespace Abc.Accounting
{
    public class AccountConsumerService : IConsumerService, IDisposable
    {
        private readonly IModel _model;
        private readonly IConnection _connection;
        private readonly IAccountService _accountService;

        public AccountConsumerService(IRabbitMqService rabbitMqService, IAccountService accountService)
        {
            _accountService = accountService;
            _connection = rabbitMqService.CreateChannel();
            _model = _connection.CreateModel();
            _model.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
            _model.ExchangeDeclare("OrderExchange", ExchangeType.Fanout, durable: true, autoDelete: false);
            _model.QueueBind(_queueName, "OrderExchange", string.Empty);
        }

        const string _queueName = "Order";

        public async Task ReadMessages()
        {
            var consumer = new AsyncEventingBasicConsumer(_model);
            consumer.Received += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var text = System.Text.Encoding.UTF8.GetString(body);
                AccountData.Orders.Add(new Order(Guid.NewGuid(), _accountService.ToAbcStandard(text)));
                await Task.CompletedTask;
                _model.BasicAck(ea.DeliveryTag, false);
            };
            _model.BasicConsume(_queueName, false, consumer);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_model.IsOpen)
            {
                _model.Close();
            }
            if (_connection.IsOpen)
            {
                _connection.Close();
            }
        }
    }
}
