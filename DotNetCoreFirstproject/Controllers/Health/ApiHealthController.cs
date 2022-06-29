using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreFirstproject.Controllers.Health
{
    public class ApiHealthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
