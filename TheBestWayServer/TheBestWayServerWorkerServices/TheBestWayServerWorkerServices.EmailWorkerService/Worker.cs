using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using TheBestWayServerWorkerServices.EmailWorkerService.MailServices;
using TheBestWayShared.SharedForWorkerService.Dtos;
using TheBestWayShared.SharedForWorkerService.RabbitMQ;
using TheBestWayShared.SharedForWorkerService.RabbitMQ.RabbitMQConsts;
using TheBestWayShared.SharedForWorkerService.RabbitMQ.RabbitMQEnums;

namespace TheBestWayServerWorkerServices.EmailWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRabbitMQClientService _rabbitMQClientService;
        private readonly SendMailService _sendMailService;
        IModel _channel;

        public Worker(ILogger<Worker> logger, SendMailService sendMailService, IRabbitMQClientService rabbitMQClientService)
        {
            _logger = logger;
            _sendMailService = sendMailService;
            _rabbitMQClientService = rabbitMQClientService;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMQClientService.ConnectRabbitMQ(exchangeType: CustomExchangeType.Direct,
                                                                   exchangeName: ResetPasswordConsts.ExchangeName,
                                                                   routingKey: ResetPasswordConsts.RoutingKey,
                                                                   queueName: ResetPasswordConsts.QueueName
                                                                   );
            _channel.BasicQos(prefetchSize: 0,
                              prefetchCount: 1,
                              global:false);
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += Consumer_Received;
            _channel.BasicConsume(queue: ResetPasswordConsts.QueueName,
                                 autoAck: false,
                                 consumer: consumer);
            await Task.CompletedTask;
        }

        private async void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            MailandResetPasswordUrlDto mailandResetPasswordUrlDto = JsonSerializer.Deserialize<MailandResetPasswordUrlDto>(Encoding.UTF8.GetString(e.Body.Span));

            _sendMailService.SendMail(mailandResetPasswordUrlDto);
            _logger.LogInformation("Mail send successfuly own EmailWorkerService Consumer");
            _channel.BasicAck(e.DeliveryTag, false);
            await Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _rabbitMQClientService.Dispose();
            return base.StopAsync(cancellationToken);
        }
    }
}