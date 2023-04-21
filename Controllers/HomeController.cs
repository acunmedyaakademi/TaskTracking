using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskTracking.Models;

namespace TaskTracking.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Tables()
		{
			return View("Tables");
		}


		public IActionResult Detay ()
		{
			return View("Detay");
		}
        public IActionResult NotFound()
        {
            return View("404");
        }


    }
}