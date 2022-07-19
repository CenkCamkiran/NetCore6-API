namespace Helpers.AppExceptionHelpers
{
	public class HashFailedException : Exception
	{
		public HashFailedException()
		{
		}

		public HashFailedException(string? message) : base(message)
		{
		}
	}
}
