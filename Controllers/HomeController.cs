using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using TaskTracking.Models;

namespace TaskTracking.Controllers
{
	public class HomeController : Controller
	{
        private readonly string connectionString = "Server=104.247.162.242\\MSSQLSERVER2017;Database=akadem58_tadimrehberi;User Id=akadem58_tr;Password=8C4ra!n07;TrustServerCertificate=True";

        private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var TaskItem = new TaskListModel();
			var UsersItem = new Users();
			int toplam = UsersItem.Is_active + UsersItem.Is_end;

   //         using (SqlConnection connection = new SqlConnection(connectionString))
			//{
			//	try
			//	{
   //                 connection.Open();
			//		var command = new SqlCommand("SELECT first_name,last_name,is_active,is_end FROM Users ", connection);
			//		var reader = command.ExecuteReader();
			//		reader.Read();
					
			//		UsersItem.First_name= reader.GetString(0);
			//		UsersItem.Last_name= reader.GetString(1);
   //                 UsersItem.Is_active= reader.GetInt32(2);
   //                 UsersItem.Is_end= reader.GetInt32(3);
			//		connection.Close();

			//		connection.Open();
			//		var command2 = new SqlCommand();

			//		connection.Close();

   //                 var command3 = new SqlCommand("SELECT Tasks.title, Tasks.state, Users.first_name, Users.last_name, Tasks.update_on FROM Tasks  JOIN Users on Tasks.[ assigning_the_job] = Users.id ORDER BY Tasks.create_on DESC", connection);
   //                 var reader3 = command3.ExecuteReader();

   //                 var taskList = new List<Tasks>();

   //                 while (reader3.Read())
   //                 {

   //                     var taskItem = new Tasks();
   //                     taskItem.Title = reader.GetString(0);
   //                     taskItem.state = reader.GetBoolean(1);
   //                     taskItem.First_name = reader.GetString(2);
   //                     taskItem.Last_name = reader.GetString(3);
   //                     taskItem.Update_on = reader.GetDateTime(4);

   //                     taskList.Add(taskItem);


   //                 }
			//		connection.Close();

			//		connection.Open();
			//		var command4 = new SqlCommand("select Tasks.title,Comment.comments,Comment.create_on,Users.first_name , Users.last_name from Comment as join Tasks  on Comment.task_id = Tasks.id join Users  on Tasks.users_id = Users.id order by c.create_on desc",connection);
			//		var reader4 = command4.ExecuteReader();

			//		var commentList = new List<Comment>();
			//		while (reader4.Read())
			//		{
			//			commentList.Add(new Comment()
			//			{
			//				Comments = reader4.GetString(0)
			//			});
			//			TaskItem.Comment = commentList;

			//		}
			//		return View(TaskItem);

   //             }
			//	catch (Exception)
			//	{

			//		throw;
			//	}
			//}


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