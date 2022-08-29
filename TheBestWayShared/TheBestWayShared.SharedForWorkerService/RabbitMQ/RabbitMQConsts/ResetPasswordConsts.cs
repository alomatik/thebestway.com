using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayShared.SharedForWorkerService.RabbitMQ.RabbitMQConsts
{
    public class ResetPasswordConsts
    {
        public const string ExchangeName = "password-reset-exchange";
        public const string RoutingKey = "password-reset-route";
        public const string QueueName = "password-reset-queue";

    }
}
