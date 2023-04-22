using Microsoft.AspNetCore.Mvc;

namespace TaskTracking.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
