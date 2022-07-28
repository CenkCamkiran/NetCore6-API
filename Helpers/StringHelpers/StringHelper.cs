using Helpers.AppExceptionHelpers;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.Net;

namespace Helpers.StringHelpers
{
	public static class StringHelper
	{
		public static void ControlObjectID(this string id, string ID)
		{
			if (ID.Length != 24)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Id must be 24 Character length";
				errorModel.ErrorCode = ((int)HttpStatusCode.UnprocessableEntity).ToString();

				throw new AppException(JsonConvert.SerializeObject(errorModel));
			}

		}
	}
}
