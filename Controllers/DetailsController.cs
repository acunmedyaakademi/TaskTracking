using Microsoft.AspNetCore.Mvc;

namespace TaskTracking.Controllers
{
	public class DetailsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
