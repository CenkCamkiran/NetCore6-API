namespace DotNetCoreFirstproject.Helpers.AppExceptionHelpers
{
    public class AppException : Exception
    {
        public AppException()
        {
        }

        public AppException(string? message) : base(message)
        {
        }
    }
}
