using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreFirstproject.Controllers
{
    public class ApiHealthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
