using System.ComponentModel.DataAnnotations;

namespace TaskTracking.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Task_id { get; set; }
        public int Assigning_the_job { get; set; }
        public DateTime Create_on { get; set; }
		public int active_task { get; set; }
		public int End_on { get; set; }
        public bool Is_confirm { get; set;}

	}
    public class UserCreate
    {
        [Required]
        public string First_name { get; set; }

        [Required]
        public string Last_name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Is_confirm { get; set; }

        public DateTime Create_on { get; set;}
    }
    public class UsersLogin
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Is_confirm { get; set; }
    }
    
}
