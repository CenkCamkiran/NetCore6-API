namespace DotNetCoreFirstproject.Helpers.AppExceptionHelpers
{
	public class ElasticSearchException: Exception
	{
		public ElasticSearchException()
		{
		}

		public ElasticSearchException(string? message) : base(message)
		{
		}
	}
}
