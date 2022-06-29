namespace DotNetCoreFirstproject.Helpers.AppExceptionHelpers
{
    public class MandatoryRequestParametersException : Exception
    {
        public MandatoryRequestParametersException()
        {
        }

        public MandatoryRequestParametersException(string? message) : base(message)
        {
        }
    }
}
