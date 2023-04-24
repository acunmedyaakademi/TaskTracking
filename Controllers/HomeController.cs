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
            if (HttpContext.Session.GetString("loginEmail") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            string LoginMail = HttpContext.Session.GetString("loginEmail");
            var TaskItem = new TaskListModel();
           
           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    var command = new SqlCommand("SELECT first_name,last_name,is_active,is_end FROM Users ", connection); //Users model
                    var reader = command.ExecuteReader();
                    List<Users> users = new List<Users>();
                    while (reader.Read())
                    {
                        Users UsersItem = new Users();

                        UsersItem.First_name = reader.GetString(0);
                        UsersItem.Last_name = reader.GetString(1);
                        UsersItem.Is_active = reader.GetInt32(2);
                        UsersItem.Is_end = reader.GetInt32(3);
                        UsersItem.Is_sum = UsersItem.Is_end + UsersItem.Is_active;
                        users.Add(UsersItem);
                    }

                    TaskItem.Users = users;
                    connection.Close();

                    connection.Open();
                    List<TaskList> taskLists= new List<TaskList>();
                    var command2 = new SqlCommand("SELECT t.title,t.state,t.update_on,u2.first_name,u2.last_name From Tasks as t JOIN Users as u on t.users_id = u.id JOIN Users as u2 on t.[ assigning_the_job] = u2.id where u.email = @Email", connection);
                    command2.Parameters.AddWithValue("@Email", LoginMail);
                    var reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                       TaskList taskList2 = new TaskList();
                        taskList2.Title= reader2.GetString(0);
                        taskList2.state= reader2.GetBoolean(1);
                        taskList2.Update_on = reader2.GetDateTime(2);
                        taskList2.First_name= reader2.GetString(3);
                        taskList2.Last_name= reader2.GetString(4);
                        
                        taskLists.Add(taskList2);
                    }
                    TaskItem.TaskList = taskLists;  
                        connection.Close();

                    connection.Open();
                    var command3 = new SqlCommand("SELECT TOP(5) Tasks.title, Tasks.state, Users.first_name, Users.last_name, Tasks.update_on FROM Tasks  JOIN Users on Tasks.[ assigning_the_job] = Users.id ORDER BY Tasks.create_on DESC", connection);//
                    var reader3 = command3.ExecuteReader();

                    var taskList = new List<Tasks>();

                    while (reader3.Read())
                    {

                        var taskItem = new Tasks();
                        taskItem.Title = reader3.GetString(0);
                        taskItem.state = reader3.GetBoolean(1);
                        taskItem.First_name = reader3.GetString(2);
                        taskItem.Last_name = reader3.GetString(3);
                        taskItem.Update_on = reader3.GetDateTime(4);

                        taskList.Add(taskItem);

                    }
                    TaskItem.Tasks= taskList;
                    connection.Close();

                    connection.Open();
                    var command4 = new SqlCommand("select TOP(5) Tasks.title,Comment.comments,Comment.create_on,Users.first_name , Users.last_name from Comment join Tasks on Comment.task_id = Tasks.id join Users  on Tasks.users_id = Users.id order by Tasks.create_on desc", connection);
                    var reader4 = command4.ExecuteReader();

                    var commentList = new List<Comment>();

                    while (reader4.Read())
                    {
                        var comment = new Comment();
                        comment.Title= reader4.GetString(0); 
                        comment.Comments = reader4.GetString(1);
                        comment.Create_on= reader4.GetDateTime(2);
                        comment.First_name= reader4.GetString(3);
                        comment.Last_name= reader4.GetString(4);

                        commentList.Add(comment);
                        

                    }

                    TaskItem.Comment = commentList;

                    return View(TaskItem);
      
                    
                   

                }
                catch (Exception)
                {

                    throw;
                }
            }



        }

        public IActionResult Tables()
        {
            return View("Tables");
        }


        public IActionResult Detay()
        {
            return View("Detay");
        }



    }
}