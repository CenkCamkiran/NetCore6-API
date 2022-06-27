using Microsoft.IdentityModel.SecurityTokenService;
using System.Runtime.Serialization;

namespace DotNetCoreFirstproject.Helpers.APIExceptionHelper
{
    public class KeycloakException : Exception
    {
        public KeycloakException()
        {
        }

        public KeycloakException(string? message) : base(message)
        {
        }

    }
}
