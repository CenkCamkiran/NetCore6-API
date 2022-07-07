namespace Helpers.AppExceptionHelpers
{
	public class KeycloakInvalidCredentialsException : Exception
	{
		public KeycloakInvalidCredentialsException()
		{
		}

		public KeycloakInvalidCredentialsException(string? message) : base(message)
		{
		}
	}
}
