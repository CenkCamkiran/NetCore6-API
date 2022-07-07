using DotNetCoreFirstproject.Controllers.Entities;
using DotNetCoreFirstproject.Helpers.Entities;
using DotNetCoreFirstproject.Helpers.HttpClientHelper.Entities.KeyCloak.CreateUser;

namespace DotNetCoreFirstproject.ServiceLayer.Interfaces
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
