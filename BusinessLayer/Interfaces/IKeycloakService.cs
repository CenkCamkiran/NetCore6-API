using Models.ControllerModels;
using Models.HelpersModels;

namespace ServiceLayer.Interfaces
{
	public interface IKeycloakService
	{
		public TokenResponse AdminAuth();
		public TokenResponse UserAuth(UserLoginRequest userCredentials);
		public TokenResponse RefreshSession(bool IsAdmin, TokenResponse token);
		public HttpResponseMessage RemoveSession(bool IsAdmin, TokenResponse token, TokenResponse? adminToken = null);
		public UserSignupResponse CreateUser(CreateUserRequest requestBody, TokenResponse token);
		public DecodedToken CheckTokenStatus(string token);
	}
}
