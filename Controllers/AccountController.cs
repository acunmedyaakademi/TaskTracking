using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TaskTracking.Models;

namespace TaskTracking.Controllers
{
    public class AccountController : Controller
    {
        private readonly string connectionString = "Server=104.247.162.242\\MSSQLSERVER2017;Database=akadem58_tadimrehberi;User Id=akadem58_tr;Password=8C4ra!n07;TrustServerCertificate=True";


        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("loginEmail") != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(UsersLogin login)
        {
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
                    command.Parameters.AddWithValue("@Email", login.Email);
                    command.Parameters.AddWithValue("@Password", login.Password);


                    var reader = command.ExecuteReader();



                    if (reader.HasRows)
                    {
                        reader.Read();
                        var verify = reader.GetBoolean(10);

                        if (verify)

                            HttpContext.Session.SetString("loginEmail",login.Email);

                            return RedirectToAction("Index","Home");


                    }

                    return Content("0");
                }

            }
            catch (Exception)
            {

                return Content("0");
            }



        }



        public IActionResult SignUp()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult SignUp(UserCreate create)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Users (first_name,last_name,email,password,create_on, is_confirm) VALUES (@first_name,@last_name,@Email,@Password,@Create_on,@Is_confirm) ", connection);
                command.Parameters.AddWithValue("@first_name", create.First_name);
                command.Parameters.AddWithValue("@last_name", create.Last_name);
                command.Parameters.AddWithValue("@Email", create.Email);
                command.Parameters.AddWithValue("@Password", create.Password);
                command.Parameters.AddWithValue("@Create_on", DateTime.Now);
                command.Parameters.AddWithValue("@Is_confirm", false);


                command.ExecuteNonQuery();
            }

            return Content("1");
        }
        public IActionResult Logout() 
        {
            HttpContext.Session.Remove("loginEmail");

            return RedirectToAction("Login","Account");
        }
    }

    //Selahattin


}
