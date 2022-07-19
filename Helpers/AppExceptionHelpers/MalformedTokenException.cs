namespace Helpers.AppExceptionHelpers
{
	public class MalformedTokenException : Exception
	{
		public MalformedTokenException()
		{
		}

		public MalformedTokenException(string? message) : base(message)
		{
		}
	}
}
