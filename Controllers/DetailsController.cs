using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TaskTracking.Models;

namespace TaskTracking.Controllers
{
	public class DetailsController : Controller
	{
        private readonly string connectionString = "Server=104.247.162.242\\MSSQLSERVER2017;Database=akadem58_tadimrehberi;User Id=akadem58_tr;Password=8C4ra!n07;TrustServerCertificate=True";

		[Route("{slug}")]
        public IActionResult Index(string slug)
		{
			var detayItem = new DetayList();

			using (SqlConnection connection = new SqlConnection(connectionString))

				try
				{
					connection.Open();
					var command = new SqlCommand("SELECT id,title,content,create_on FROM Tasks WHERE slug = @slug", connection);
					command.Parameters.AddWithValue("@slug", slug);
					var reader = command.ExecuteReader();

					reader.Read();
					detayItem.id = reader.GetInt32(0);
					detayItem.Title = reader.GetString(1);
					detayItem.Content = reader.GetString(2);
					connection.Close();

					connection.Open();
					var command2 = new SqlCommand("SELECT c.comments,u.first_name,u.last_name FROM Comment as c JOIN Users as u on c.user_id = u.id WHERE c.id = @id",connection);
					command2.Parameters.AddWithValue("@id", detayItem.id);

					var reader2 = command2.ExecuteReader();

					var detayComment = new List<detayCommentItem>();

					while (reader2.Read())
					{
						detayComment.Add(new detayCommentItem()
						{
							comment = reader2.GetString(0),
							First_name= reader2.GetString(1),
							Last_name= reader2.GetString(2),
						});
						detayItem.CommentItems = detayComment;
					}
					connection.Close();

					connection.Open();
					var command3 = new SqlCommand("SELECT u.first_name,u.last_name,t.update_on,t.create_on,t.slug FROM Tasks as t JOIN Users as u on t.[ assigning_the_job] = u.assigning_the_job WHERE t.slug =@slug ", connection);
					command3.Parameters.AddWithValue("@slug", slug);
					var reader3 = command3.ExecuteReader();
					var detayShow = new List<Tasks>();
					
					reader3.Read();
					detayShow.Add(new Tasks()
					{
						First_name = reader3.GetString(0),
						Last_name = reader3.GetString(1),
						Update_on = reader3.GetDateTime(2),
						Create_on= reader3.GetDateTime(3),
					});
					detayItem.taskItem = detayShow;
					
					return View(detayItem);
				}
				catch (Exception)
				{

					throw;
				}

				
		}

		[HttpPost]
		public IActionResult Index()
		{

			return View();
		}
	}
}
