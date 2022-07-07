namespace Helpers.AppExceptionHelpers
{
    public class KeycloakException : Exception
    {
        public KeycloakException()
        {
        }

        public KeycloakException(string? message) : base(message)
        {
        }

    }
}
