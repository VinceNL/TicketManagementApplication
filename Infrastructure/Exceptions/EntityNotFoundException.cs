using System.Runtime.Serialization;

namespace Infrastructure.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }

        public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

#pragma warning disable SYSLIB0051 // Type or member is obsolete
        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore SYSLIB0051 // Type or member is obsolete
        {
        }
    }
}