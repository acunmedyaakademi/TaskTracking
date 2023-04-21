using Microsoft.AspNetCore.Mvc;

namespace TaskTracking.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View("Login");
        }



        public IActionResult Password()
        {

            return View("Password");
        }
    }

    

    
}
