namespace Helpers.AppExceptionHelpers
{
    public class EmailFormatException : Exception
    {
        public EmailFormatException()
        {
        }

        public EmailFormatException(string? message) : base(message)
        {
        }
    }
}
