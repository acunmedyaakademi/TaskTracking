namespace TaskTracking.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Task_id { get; set; }
        public string Comments { get; set; }
        public DateTime Create_on { get; set; }
        public int User_id { get; set; }
    }
}
