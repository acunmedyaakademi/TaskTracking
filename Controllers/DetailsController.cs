using Microsoft.AspNetCore.Mvc;

namespace TaskTracking.Controllers
{
	public class DetailsController : Controller
	{
        private readonly string connectionString = "Server=104.247.162.242\\MSSQLSERVER2017;Database=akadem58_tadimrehberi;User Id=akadem58_tr;Password=8C4ra!n07;TrustServerCertificate=True";


        public IActionResult Index()
		{
			return View();
		}
	}
}
