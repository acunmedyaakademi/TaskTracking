using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracking.Controllers
{
	public class DetailsController : Controller
	{
		public IActionResult Index()
		{
         string connectionString = "Server=104.247.162.242\\MSSQLSERVER2017;Database=akadem58_tadimrehberi;User Id=akadem58_tr;Password=8C4ra!n07;TrustServerCertificate=True";

            if (HttpContext.Session.GetString("loginEmail") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    var command = new SqlCommand("select * from Users where email = @Email and password = @Password ", connection);
                    //command.Parameters.AddWithValue("@Password", login.Password);


                    var reader = command.ExecuteReader();



                    if (reader.HasRows)
                    {
                        reader.Read();
                        var verify = reader.GetBoolean(10);

                        if (verify)

                            //HttpContext.Session.SetString("loginEmail", login.Email);

                        return RedirectToAction("Index", "Home");


                    }

                    return View("../Home/Index");
                    //return Content("0");
                }

            }
            catch (Exception)
            {

                return Content("0");
            }
            return View();
		}
	}
}
