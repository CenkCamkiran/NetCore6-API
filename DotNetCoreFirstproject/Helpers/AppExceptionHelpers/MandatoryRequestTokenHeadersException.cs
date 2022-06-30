namespace DotNetCoreFirstproject.Helpers.AppExceptionHelpers
{
    public class MandatoryRequestTokenHeadersException : Exception
    {
        public MandatoryRequestTokenHeadersException()
        {
        }

        public MandatoryRequestTokenHeadersException(string? message) : base(message)
        {
        }

    }
}
