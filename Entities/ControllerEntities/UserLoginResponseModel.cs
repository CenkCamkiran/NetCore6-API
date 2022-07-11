using Newtonsoft.Json;

namespace Entities.ControllerEntities
{
    public class UserLoginResponseModel
    {
        public string accessToken { get; set; }

        public int expiresIn { get; set; }

        public string refreshToken { get; set; }

        public int refreshExpiresIn { get; set; }

        public string tokenType { get; set; }

        public string sessionState { get; set; }
    }
}
