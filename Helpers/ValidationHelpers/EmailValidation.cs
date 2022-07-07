using System.Net.Mail;

namespace Helpers.ValidationHelpers
{
    public class EmailValidation
    {
        public EmailValidation()
        {
        }

        public bool IsEmailValid(string email)
        {
            var trimmedEmail = email.Trim();

            MailAddress EmailAddress;
            bool IsEmailValid = false;

            if (trimmedEmail.StartsWith("."))
            {
                return false;
            }
            else
            {
                IsEmailValid = MailAddress.TryCreate(email, out EmailAddress);
            }

            return IsEmailValid;

        }
    }
}
