using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayShared.SharedForWorkerService.RabbitMQ.RabbitMQEnums;

namespace TheBestWayShared.SharedForWorkerService.RabbitMQ
{
    public class RabbitMQClientService : IRabbitMQClientService
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private IModel _channel;
        private readonly ILogger<RabbitMQClientService> _logger;

        public RabbitMQClientService(IConnectionFactory connectionFactory, ILogger<RabbitMQClientService> logger)
        {
            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.CreateConnection();
            CreateChannel();
            _logger = logger;
        }

        public IModel ConnectRabbitMQ(CustomExchangeType exchangeType, string exchangeName, string routingKey, string queueName)
        {
            switch (exchangeType)
            {
                case CustomExchangeType.Fanout:
                    _channel.ExchangeDeclare(exchange: exchangeName,
                                             type: ExchangeType.Fanout,
                                             durable: true,
                                             autoDelete: false,
                                             arguments: null);
                    break;
                case CustomExchangeType.Direct:
                    _channel.ExchangeDeclare(exchange: exchangeName,
                                             type: ExchangeType.Direct,
                                             durable: true,
                                             autoDelete: false,
                                             arguments: null);
                    break;
                case CustomExchangeType.Topic:
                    _channel.ExchangeDeclare(exchange: exchangeName,
                                             type: ExchangeType.Topic,
                                             durable: true,
                                             autoDelete: false,
                                             arguments: null);
                    break;
            }
            _logger.LogInformation("Exchange declare...");

            _channel.QueueDeclare(queue: queueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            _logger.LogInformation("Queue declare...");


            _channel.QueueBind(queue: queueName,
                               exchange: exchangeName,
                               routingKey: routingKey,
                               arguments: null);

            _logger.LogInformation("Queue bind...");

            return _channel;
        }

        private void CreateChannel()
        {
            if (_channel is { IsOpen: true })
            {
                _logger.LogInformation("Return channel...");
                return;

            }
            //_logger.LogInformation("Create channel...");
            _channel = _connection.CreateModel();
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();
            _channel = default;

            _connection?.Close();
            _connection?.Dispose();

            _logger.LogInformation("Connection to RabbitMQ closed.");
        }
    }
}
