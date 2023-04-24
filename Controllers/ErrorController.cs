using Microsoft.AspNetCore.Mvc;

namespace TaskTracking.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult NotModified() {
            return View();
        }
    }
}
