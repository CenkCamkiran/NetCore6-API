using Newtonsoft.Json;

namespace Entities.ControllerEntities
{
    public class UserLoginRequestModel
    {
        public string username { get; set; }

        public string password { get; set; }

        public string hash { get; set; }
    }
}
