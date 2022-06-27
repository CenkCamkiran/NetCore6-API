using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Helpers.Entities.Keycloak
{
    [Serializable]
    public class CustomKeycloakErrorModel
    {
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        public string KeycloakToken { get; set; }
    }
}
