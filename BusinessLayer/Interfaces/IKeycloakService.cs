using Entities.ControllerEntities;
using Entities.HelpersEntities;

namespace BusinessLayer.Interfaces
{
	public interface IKeycloakService
	{
		public Task<TokenResponseModel> AdminAuth();
		public Task<TokenResponseModel> UserAuth(UserLoginRequestModel userCredentials);
		public Task<TokenResponseModel> RefreshSession(bool IsAdmin, TokenResponseModel token);
		public Task<TokenResponseModel> RemoveSession(bool IsAdmin, TokenResponseModel token);
		public Task<TokenResponseModel> CreateUser(CreateUserRequestModel requestBody, TokenResponseModel token);
	}
}
