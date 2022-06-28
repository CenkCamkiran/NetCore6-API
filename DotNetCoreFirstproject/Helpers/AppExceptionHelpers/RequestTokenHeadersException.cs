namespace DotNetCoreFirstproject.Helpers.AppExceptionHelpers
{
    public class RequestTokenHeadersException : Exception
    {
        public RequestTokenHeadersException()
        {
        }

        public RequestTokenHeadersException(string? message) : base(message)
        {
        }

    }
}
