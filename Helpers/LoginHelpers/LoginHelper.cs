using Helpers.AppExceptionHelpers;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.Net;

namespace Helpers.LoginHelpers
{
	public static class LoginHelper
	{

		public static void CheckLoginFields(this string username, string password)
		{
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Username and password cannot be empty or null";
				errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

				throw new MandatoryRequestBodyParametersException(JsonConvert.SerializeObject(errorModel));
			}
		}
	}
}
