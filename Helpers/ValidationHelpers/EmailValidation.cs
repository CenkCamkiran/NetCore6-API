using Helpers.AppExceptionHelpers;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;

namespace Helpers.ValidationHelpers
{
	public class EmailValidation
	{
		public EmailValidation()
		{
		}

		public void IsEmailValid(string email)
		{
			var trimmedEmail = email.Trim();

			MailAddress EmailAddress;
			bool IsEmailValid = false;

			if (trimmedEmail.StartsWith("."))
			{
				IsEmailValid = false;
			}
			else
			{
				IsEmailValid = MailAddress.TryCreate(email, out EmailAddress);
			}

			if (!IsEmailValid)
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Email Format is not correct";
				errorModel.ErrorCode = ((int)HttpStatusCode.UnprocessableEntity).ToString();

				throw new EmailFormatException(JsonConvert.SerializeObject(errorModel));
			}

		}
	}
}
