namespace Entities.HelpersEntities
{
    [Serializable]
    public class CustomKeycloakErrorModel
    {
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        public TokenResponseModel? KeycloakToken { get; set; }
    }
}
