﻿using Sitecore.Messaging.Services;

namespace Abc.Accounting
{
    public class ConsumerHostedService : BackgroundService
    {
        private readonly IConsumerService _consumerService;
        public ConsumerHostedService(IConsumerService consumerService)
        {
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _consumerService.ReadMessages();
        }
    }
}