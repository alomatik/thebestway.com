using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheBestWayServerAPI.Application.Abstractions.RabbitMQPublishers;
using TheBestWayShared.SharedForWorkerService.Dtos;
using TheBestWayShared.SharedForWorkerService.RabbitMQ;
using TheBestWayShared.SharedForWorkerService.RabbitMQ.RabbitMQConsts;
using TheBestWayShared.SharedForWorkerService.RabbitMQ.RabbitMQEnums;

namespace TheBestWayServerAPI.Infrastructure.Services.RabbitMQPublisher
{
    public class RabbitMQResetPasswordPublisher : IRabbitMQResetPasswordPublisher
    {
        private readonly IRabbitMQClientService _rabbitMQClientService;
        ILogger<RabbitMQResetPasswordPublisher> _logger;

        public RabbitMQResetPasswordPublisher(IRabbitMQClientService rabbitMQClientService, ILogger<RabbitMQResetPasswordPublisher> logger)
        {
            _rabbitMQClientService = rabbitMQClientService;
            _logger = logger;
        }

        public void Publish(MailandResetPasswordUrlDto mailandResetPasswordUrlDto)
        {
            var jsonBody = JsonSerializer.Serialize(mailandResetPasswordUrlDto);
            IModel channel = _rabbitMQClientService.ConnectRabbitMQ(exchangeType: CustomExchangeType.Direct,
                                                                    exchangeName: ResetPasswordConsts.ExchangeName,
                                                                    routingKey: ResetPasswordConsts.RoutingKey,
                                                                    queueName: ResetPasswordConsts.QueueName
                                                                    );
            channel.BasicPublish(exchange: ResetPasswordConsts.ExchangeName,
                                  routingKey: ResetPasswordConsts.RoutingKey,
                                  body: Encoding.UTF8.GetBytes(jsonBody));
            _logger.LogInformation("Successfuly send message own ResetPasswordPublisher.");
        }
    }
}
