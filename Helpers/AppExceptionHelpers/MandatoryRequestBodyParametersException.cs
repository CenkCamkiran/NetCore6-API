namespace Helpers.AppExceptionHelpers
{
    public class MandatoryRequestBodyParametersException : Exception
    {
        public MandatoryRequestBodyParametersException()
        {
        }

        public MandatoryRequestBodyParametersException(string? message) : base(message)
        {
        }
    }
}
