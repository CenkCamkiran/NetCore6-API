using System.Net.Mail;

namespace DotNetCoreFirstproject.Helpers.ValidationHelpers
{
    public class EmailValidation
    {
        public EmailValidation()
        {
        }

        bool IsEmailValid(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.StartsWith("."))
            {
                return false;
            }
            else
            {

            }
            MailAddress.TryCreate();
            var addr = new System.Net.Mail.MailAddress(email);

            return addr.Address == trimmedEmail;

        }
    }
}
