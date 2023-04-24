namespace TaskTracking.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Task_id { get; set; }
        public string Comments { get; set; }
        public DateTime Create_on { get; set; }
        public int User_id { get; set; }

        public int id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }

        public string Title { get; set; }   
    }
    public class CommentList
    {
        public int Id { get; set; }
        public int Task_id { get; set; }
        public string Comments { get; set; }
        public DateTime Create_on { get; set; }
        public int User_id { get; set; }

        public int id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }

        public string Title { get; set; }
        public int task_id { get; set; }
        
    }
    public class detayCommentItem
    {
        public string comment { get; set; }

        public string First_name { get; set; }
        public string Last_name { get; set; }

        public DateTime create_on { get; set; }
    }
}
