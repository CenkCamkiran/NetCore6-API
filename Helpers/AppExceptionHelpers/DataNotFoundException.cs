namespace Helpers.AppExceptionHelpers
{
	public class DataNotFoundException : Exception
	{
		public DataNotFoundException()
		{
		}

		public DataNotFoundException(string? message) : base(message)
		{
		}
	}
}
