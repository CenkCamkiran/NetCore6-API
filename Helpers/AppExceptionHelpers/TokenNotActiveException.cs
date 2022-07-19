namespace Helpers.AppExceptionHelpers
{
	public class TokenNotActiveException : Exception
	{
		public TokenNotActiveException()
		{
		}

		public TokenNotActiveException(string? message) : base(message)
		{
		}
	}
}
