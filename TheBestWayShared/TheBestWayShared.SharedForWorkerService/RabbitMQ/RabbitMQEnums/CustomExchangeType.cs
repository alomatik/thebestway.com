using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayShared.SharedForWorkerService.RabbitMQ.RabbitMQEnums
{
    public enum CustomExchangeType
    {
        Fanout = 0,
        Direct = 1,
        Topic = 2,
    }
}
