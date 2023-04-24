using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TaskTracking.Models;

namespace TaskTracking.Controllers
{
	public class TableController : Controller
	{
        private readonly string connectionString = "Server=104.247.162.242\\MSSQLSERVER2017;Database=akadem58_tadimrehberi;User Id=akadem58_tr;Password=8C4ra!n07;TrustServerCertificate=True";


        public IActionResult Index()
		{
			return View();
		}
        public IActionResult AllList()
        {
            var taskList = new List<Tasks>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Tasks.title, Tasks.state, Users.first_name, Users.last_name, Tasks.update_on FROM Tasks  JOIN Users on Tasks.[ assigning_the_job] = Users.id ORDER BY Tasks.create_on DESC", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var taskItem = new Tasks();
                    taskItem.Title = reader.GetString(0);
                    taskItem.state = reader.GetBoolean(1);
                    taskItem.First_name = reader.GetString(2);
                    taskItem.Last_name = reader.GetString(3);
                    taskItem.Update_on = reader.GetDateTime(4);

                    taskList.Add(taskItem);


                }
            }

                return View(taskList);
        }

    }
}
