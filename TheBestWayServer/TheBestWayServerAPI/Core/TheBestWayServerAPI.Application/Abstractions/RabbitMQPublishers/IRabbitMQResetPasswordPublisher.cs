using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBestWayShared.SharedForWorkerService.Dtos;
using TheBestWayShared.SharedForWorkerService.RabbitMQ;

namespace TheBestWayServerAPI.Application.Abstractions.RabbitMQPublishers
{
    public interface IRabbitMQResetPasswordPublisher
    {
        public void Publish(MailandResetPasswordUrlDto mailandResetPasswordUrlDto);
    }
}
