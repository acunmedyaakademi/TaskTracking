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
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsersLogin login)
        {
          

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();



                var command = new SqlCommand("select * from Users where email = @Email and password = @Password and is_confirm =@Is_confirm ", connection);
                command.Parameters.AddWithValue("@Email", login.Email);
                command.Parameters.AddWithValue("@Password", login.Password);
                command.Parameters.AddWithValue("@@Is_confirm", login.Is_confirm);

                var reader = command.ExecuteReader();

                var pas = login.Password;
                var mail = login.Email;
                var verify = login.Is_confirm;

                if (verify = true && mail=="@Email" && pas =="@Password") 
                {
                    return Content("1");
                }
                else
                {
                    return Content("0");
                }
            }

                
        }



        public IActionResult SignUp()
        {

            return View();
        }

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
    }

    //Selahattin

    
}
