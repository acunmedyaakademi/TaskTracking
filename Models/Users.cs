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
		public int Is_active { get; set; }
		public int Is_end { get; set; }
        public bool Is_confirm { get; set;}

        public string Mail_code { get; set; }

      
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
    public class UserSendCode {
        public string Email { get; set; }
       
    }
    public class ControlCode
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mail_code { get; set; }

    }
    public class VerifyCode
    {
        public string Email { get; set; }
        public string Mail_code { get; set; }
    }
    
}
