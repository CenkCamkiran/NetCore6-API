using Helpers.AppExceptionHelpers;
using Models.HelpersModels;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Helpers.CryptoHelpers
{
	public class CryptoHelper
	{
		public CryptoHelper()
		{
		}

		public string ComputeSha256Hash(string rawData)
		{
			// Create a SHA256   
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// ComputeHash - returns byte array  
				byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

				// Convert byte array to a string   
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < bytes.Length; i++)
				{
					builder.Append(bytes[i].ToString("x2"));
				}
				return builder.ToString().ToUpper();
			}
		}

		public void CheckHash(string requestHash, string computedHash)
		{
			if (!requestHash.Equals(computedHash, StringComparison.OrdinalIgnoreCase))
			{
				CustomAppError errorModel = new CustomAppError();
				errorModel.ErrorMessage = "Hash failed";
				errorModel.ErrorCode = ((int)HttpStatusCode.BadRequest).ToString();

				throw new HashFailedException(JsonConvert.SerializeObject(errorModel));
			}

		}

	}
}
