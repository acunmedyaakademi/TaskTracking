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

	}
    
}
