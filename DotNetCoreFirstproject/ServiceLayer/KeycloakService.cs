using DotNetCoreFirstproject.Helpers.HttpClientHelper;

namespace DotNetCoreFirstproject.ServiceLayer
{
    public class KeycloakService
    {

        public void UserSignUp()
        {
            HttpClientHelper<> httpClientHelper = new HttpClientHelper();
            httpClientHelper.MakeAdminRequest();
        }

    }
}
