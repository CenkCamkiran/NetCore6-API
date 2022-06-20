using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreFirstproject.Controllers
{
    public class UserLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
