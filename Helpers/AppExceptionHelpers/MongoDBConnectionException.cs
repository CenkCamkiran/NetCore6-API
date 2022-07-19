namespace Helpers.AppExceptionHelpers
{
	public class MongoDBConnectionException : Exception
	{
		public MongoDBConnectionException()
		{
		}

		public MongoDBConnectionException(string? message) : base(message)
		{
		}
	}
}
