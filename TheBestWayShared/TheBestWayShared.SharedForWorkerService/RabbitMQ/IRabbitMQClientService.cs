using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayShared.SharedForWorkerService.RabbitMQ.RabbitMQEnums;

namespace TheBestWayShared.SharedForWorkerService.RabbitMQ
{
    public interface IRabbitMQClientService:IDisposable
    {
        IModel ConnectRabbitMQ(CustomExchangeType exchangeType, string exchangeName, string routingKey, string queueName);
    }
}
