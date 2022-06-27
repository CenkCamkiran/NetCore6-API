using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.Token;

namespace DotNetCoreFirstproject.Helpers.Entities.Keycloak
{
    [Serializable]
    public class CustomKeycloakErrorModel
    {
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        public TokenResponseModel? KeycloakToken { get; set; }
    }
}
