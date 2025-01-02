using System.Runtime.Serialization;

namespace Infrastructure.Exceptions
{
    [Serializable]
    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException()
        {
        }

        public TicketNotFoundException(string? message) : base(message)
        {
        }

        public TicketNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

#pragma warning disable SYSLIB0051 // Type or member is obsolete
        protected TicketNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore SYSLIB0051 // Type or member is obsolete
        {
        }
    }
}
