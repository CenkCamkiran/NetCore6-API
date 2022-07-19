using Helpers.AppExceptionHelpers;
using Models.HelpersModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.TokenHelpers
{
	public static class TokenHelper
	{
		public static bool ExtractToken(this string tokenHeader, int length)
		{
			if (string.IsNullOrEmpty(tokenHeader) || length > tokenHeader.Length)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "AccessToken or RefreshToken not found in request headers.";
				errorModel.ErrorCode = ((int)HttpStatusCode.InternalServerError).ToString();

				throw new MandatoryRequestTokenHeadersException(JsonConvert.SerializeObject(errorModel));
			}

			return true;
		}

		public static void CheckToken(this string accessToken, string refreshToken)
		{
			if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
			{

				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "AccessToken and RefreshToken must not be null or empty";
				errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

				throw new MandatoryRequestBodyParametersException(JsonConvert.SerializeObject(errorModel));
			}
		}
	}
}
