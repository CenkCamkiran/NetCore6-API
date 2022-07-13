using Models.ControllerModels;
using Models.HelpersModels;

namespace BusinessLayer.Interfaces
{
	public interface IKeycloakService
	{
		public TokenResponse AdminAuth();
		public TokenResponse UserAuth(UserLoginRequest userCredentials);
		public TokenResponse RefreshSession(bool IsAdmin, TokenResponse token);
		public object RemoveSession(bool IsAdmin, TokenResponse token);
		public UserSignupResponse CreateUser(CreateUserRequest requestBody, TokenResponse token);
		public DecodedToken CheckTokenStatus(string token);
	}
}
