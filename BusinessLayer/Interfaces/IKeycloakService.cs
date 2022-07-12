using Models.ControllerModels;
using Models.HelpersModels;

namespace BusinessLayer.Interfaces
{
	public interface IKeycloakService
	{
		public Task<TokenResponse> AdminAuth();
		public Task<TokenResponse> UserAuth(UserLoginRequest userCredentials);
		public Task<TokenResponse> RefreshSession(bool IsAdmin, TokenResponse token);
		public Task<TokenResponse> RemoveSession(bool IsAdmin, TokenResponse token);
		public Task<TokenResponse> CreateUser(CreateUserRequest requestBody, TokenResponse token);
	}
}
