namespace Helpers.AppExceptionHelpers
{
	public class RedisDBConnectionException : Exception
	{
		public RedisDBConnectionException()
		{
		}

		public RedisDBConnectionException(string? message) : base(message)
		{
		}
	}
}
