using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheBestWayServerAPI.Application.Exceptions
{
    public class IdentityException : Exception
    {
        public IdentityError[] IdentityErrors { get; }

        public IdentityException()
        {
        
        }
        public IdentityException(IdentityError[] identityErrors)
        {
            IdentityErrors = identityErrors;
        }

        public IdentityException(string? message) : base(message)
        {
        }

        public IdentityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IdentityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
