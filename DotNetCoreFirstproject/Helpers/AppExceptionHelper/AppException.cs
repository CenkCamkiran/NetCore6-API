using System.Runtime.Serialization;

namespace DotNetCoreFirstproject.Helpers.APIExceptionHelper
{
    public class AppException : Exception
    {
        public AppException()
        {
        }

        public AppException(string? message) : base(message)
        {
        }

        public AppException(string? message) : base(message)
        {
        }

        public AppException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
,
    }
}
