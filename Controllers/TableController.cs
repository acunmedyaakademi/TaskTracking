using Microsoft.AspNetCore.Mvc;

namespace TaskTracking.Controllers
{
	public class TableController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
