using Newtonsoft.Json;

namespace DotNetCoreFirstproject.Controllers.Entities
{
    public class UserLoginRequestModel
    {
        public string username { get; set; }

        public string password { get; set; }

        public string hash { get; set; }
    }
}
