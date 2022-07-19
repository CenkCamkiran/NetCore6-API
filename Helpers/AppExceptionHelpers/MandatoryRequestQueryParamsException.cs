namespace Helpers.AppExceptionHelpers
{
	public class MandatoryRequestQueryParamsException : Exception
	{
		public MandatoryRequestQueryParamsException()
		{
		}

		public MandatoryRequestQueryParamsException(string? message) : base(message)
		{
		}
	}
}
