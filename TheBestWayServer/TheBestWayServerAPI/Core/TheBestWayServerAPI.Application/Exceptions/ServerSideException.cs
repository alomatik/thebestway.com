using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.Exceptions
{
    public class ServerSideException : Exception
    {
        public ServerSideException()
        {

        }

        public ServerSideException(string? message) : base(message)
        {

        }

        public ServerSideException(string? message, Exception? innerException) : base(message, innerException)
        {

        }

        protected ServerSideException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
