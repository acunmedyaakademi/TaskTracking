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
			if (HttpContext.Session.GetString("loginEmail") == null)
			{
				return RedirectToAction("Login", "Account");
			}
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



    }
}