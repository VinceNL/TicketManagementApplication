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
    }
}